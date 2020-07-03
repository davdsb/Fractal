﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Fractal.Models;

namespace Fractal.ViewModels
{
    public class ShapeControlViewModel : INotifyPropertyChanged
    {
        private int _cornerRadius;
        public int CornerRadius
        {
            get => _cornerRadius;
            set { _cornerRadius = value; OnPropertyChanged("CornerRadius"); }
        }

        private Brush _backgroundColor;
        public Brush BackgroundColor
        {
            get => _backgroundColor;
            set { _backgroundColor = value; OnPropertyChanged(("BackgroundColor")); }
        }

        public Point OriginPoint
        {
            get => new Point(XOrigin, YOrigin);
            set
            {
                XOrigin = value.X;
                YOrigin = value.Y;
                OnPropertyChanged("OriginPoint");
            }
        }

        private double _xOrigin;
        public double XOrigin
        {
            get { return _xOrigin; }
            set { _xOrigin = value; OnPropertyChanged("XOrigin"); }
        }

        private double _yOrigin;
        public double YOrigin
        {
            get { return _yOrigin; }
            set { _yOrigin = value; OnPropertyChanged("YOrigin"); }
        }

        private Point _shape;
        public Point Shape
        {
            get => _shape;
            set { _shape = value; OnPropertyChanged("Shape"); }
        }

        public ShapeControlViewModel()
        {
            XOrigin = 50;
            YOrigin = 50;

            BackgroundColor = Brushes.AliceBlue;
            CornerRadius = 10;

            //Commands
            UpdateOriginCommand = new RelayCommand(UpdateOrigin);

        }

        public ICommand UpdateOriginCommand { get; set; }
        public void UpdateOrigin(object param)
        {
            Canvas canvas = param as Canvas;
            var p = Mouse.GetPosition(canvas);

            XOrigin = p.X;
            YOrigin = p.Y;
        }

        #region INotify boiler plate
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged == null) return;
            var e = new PropertyChangedEventArgs(propertyName);
            this.PropertyChanged(this, e);
        }
        #endregion
    }
}
