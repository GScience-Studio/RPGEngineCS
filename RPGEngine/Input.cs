using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;

namespace RPGEngine
{
    /// <summary>
    /// 获取用户点击状态
    /// </summary>
    public static class TouchInput
    {
        /// <summary>
        /// 上一次检测时的状态
        /// </summary>
        private static TouchLocation _touchLocation;

        /// <summary>
        /// 上次鼠标状态
        /// </summary>
        private static MouseState _previousMouseState;

        /// <summary>
        /// 当前鼠标状态
        /// </summary>
        private static MouseState _nowMouseState;

        /// <summary>
        /// 是否使用鼠标
        /// </summary>
        private static bool _useMouse;

        public static void Initialize()
        {
            TouchPanel.EnabledGestures = GestureType.None;
            TouchPanel.DisplayHeight = RPGGame.GetClientBounds().Height;
            TouchPanel.DisplayWidth = RPGGame.GetClientBounds().Width;
            _useMouse = !TouchPanel.GetCapabilities().IsConnected;
        }

        private static void Update()
        {
            if (_useMouse)
            {
                var mouseState = Mouse.GetState();
                if (_nowMouseState == mouseState)
                    return;
                _previousMouseState = _nowMouseState;
                _nowMouseState = mouseState;

            }
            else
            {
                var touchPointList = TouchPanel.GetState();
                if (touchPointList.Count == 0)
                    return;

                _touchLocation = touchPointList[touchPointList.Count - 1];
            }
        }
        private static bool CursorInWindow()
        {
            return RPGGame.GetClientBounds().Contains(_nowMouseState.Position + RPGGame.GetClientBounds().Location);
        }

        public static bool IsPressed
        {
            get
            {
                Update();

                if (_useMouse)
                    return CursorInWindow() && _nowMouseState.LeftButton == ButtonState.Pressed;

                //是否为活跃窗体
                if (!RPGGame.Game.IsActive)
                    return false;

                return _touchLocation.State == TouchLocationState.Pressed;
            }
        }

        public static bool IsRelease
        {
            get
            {
                Update();

                if (_useMouse)
                    return CursorInWindow() && _nowMouseState.LeftButton == ButtonState.Released;

                //是否为活跃窗体
                if (!RPGGame.Game.IsActive)
                    return false;

                return _touchLocation.State == TouchLocationState.Released;
            }
        }

        public static bool IsClick
        {
            get
            {
                Update();

                if (_useMouse)
                    return CursorInWindow() && _previousMouseState.LeftButton == ButtonState.Pressed && _nowMouseState.LeftButton == ButtonState.Released;

                //是否为活跃窗体
                if (!RPGGame.Game.IsActive)
                    return false;

                if (!_touchLocation.TryGetPreviousLocation(out var previousLocation))
                    return false;

                return IsRelease && previousLocation.State == TouchLocationState.Moved;
            }
        }

        public static Vector2 Position
        {
            get
            {
                Update();
                
                return _useMouse ? _nowMouseState.Position.ToVector2() : _touchLocation.Position;
            }
        }
    }
}