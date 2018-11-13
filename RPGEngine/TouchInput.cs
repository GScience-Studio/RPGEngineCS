using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;

namespace RPGEngine
{
    public static class TouchInput
    {
        public class CheckResult
        {
            private readonly bool _ok;
            public Point Pos;

            public CheckResult(bool ok, Point pos = new Point())
            {
                _ok = ok;
                Pos = pos;
            }

            public static implicit operator bool(CheckResult result)
            {
                return result._ok;
            }
        }
        private static bool _useMouse;
        private static ButtonState _leftButtonState = ButtonState.Released;
        private static DateTime _pressedFrom;

        private static readonly Dictionary<GestureType, List<GestureSample>> _gestures =
            new Dictionary<GestureType, List<GestureSample>>();
        public static void Initialize()
        {
            TouchPanel.EnableMouseGestures = true;
            TouchPanel.EnableMouseTouchPoint = true;
            TouchPanel.EnabledGestures = GestureType.Tap | GestureType.Hold | GestureType.FreeDrag;
            RegisterGesture(GestureType.Tap);
            RegisterGesture(GestureType.Hold);
            RegisterGesture(GestureType.FreeDrag);
            _useMouse = !TouchPanel.GetCapabilities().IsConnected;
        }

        private static void RegisterGesture(GestureType gestureType)
        {
            _gestures.Add(gestureType, new List<GestureSample>());
        }

        private static void RefreshGestures()
        {
            while (TouchPanel.IsGestureAvailable)
            {
                var gesture = TouchPanel.ReadGesture();
                _gestures[gesture.GestureType].Add(gesture);
            }
        }

        private static GestureSample? GetGesture(GestureType gestureType)
        {
            if (!_gestures.ContainsKey(gestureType))
                throw new Exception("A non registered gesture " + gestureType);
            var gestureList = _gestures[gestureType];
            if (gestureList.Count == 0)
                return null;

            var gesture = gestureList[0];
            _gestures[gestureType].Remove(gesture);
            return gesture;
        }

        private static bool CursorInWindow()
        {
            return RPGGame.GetClientBounds().Contains(Mouse.GetState().Position + RPGGame.GetClientBounds().Location);
        }

        public static CheckResult IsHold()
        {
            //是否为活跃窗体
            if (!RPGGame.Game.IsActive)
                return new CheckResult(false);

            //鼠标操作
            if (_useMouse)
            {
                _leftButtonState = Mouse.GetState().LeftButton;

                if (_leftButtonState == ButtonState.Released)
                {
                    _pressedFrom = DateTime.UtcNow;
                    return new CheckResult(false);
                }

                if ((DateTime.UtcNow - _pressedFrom).TotalSeconds < 1)
                    return new CheckResult(false);

                return !CursorInWindow() ? 
                    new CheckResult(false) : 
                    new CheckResult(true, Mouse.GetState().Position);
            }

            //手势操作
            RefreshGestures();

            var gesture = GetGesture(GestureType.Hold);

            return gesture == null ? 
                new CheckResult(false) : 
                new CheckResult(true, gesture.Value.Position.ToPoint());
        }

        public static CheckResult IsTap()
        {
            //是否为活跃窗体
            if (!RPGGame.Game.IsActive)
                return new CheckResult(false);

            //鼠标操作
            if (_useMouse)
            {
                if (_leftButtonState == ButtonState.Pressed)
                {
                    _leftButtonState = Mouse.GetState().LeftButton;
                }
                else
                {
                    _leftButtonState = Mouse.GetState().LeftButton;
                    return new CheckResult(false);
                }

                if (_leftButtonState != ButtonState.Released)
                    return new CheckResult(false);

                return !CursorInWindow() ? new CheckResult(false) : new CheckResult(true, Mouse.GetState().Position);
            }

            //手势操作
            RefreshGestures();

            var gesture = GetGesture(GestureType.Tap);

            return gesture == null ? new CheckResult(false) : new CheckResult(true, gesture.Value.Position.ToPoint());
        }

        public static CheckResult IsDrag()
        {
            //是否为活跃窗体
            if (!RPGGame.Game.IsActive)
                return new CheckResult(false);

            //鼠标操作
            if (_useMouse)
            {
                if (_leftButtonState == ButtonState.Pressed && CursorInWindow())
                    return new CheckResult(true, Mouse.GetState().Position);
                return new CheckResult(false);
            }

            //手势操作
            RefreshGestures();

            var gesture = GetGesture(GestureType.FreeDrag);

            return gesture != null ? 
                new CheckResult(true, gesture.Value.Position.ToPoint()) : 
                new CheckResult(false);
        }
    }
}