﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Avalonia;
using ReactiveUI;

namespace DiagramEditor.Models.DiagramObjects
{
    public class DiagramElement : DiagramBaseElement
    {
        public DiagramElement() 
        {
            /* isInterface = false;
             stereotype = "stereo";
             visibility = "visibility";
             attributes = new ObservableCollection<DiagramElementAttribute> { };
             operations = new ObservableCollection<DiagramElementOperation> { };
             startPoint = new Point(50, 50); */
            width = 100;
            height = 100;
            leftEllipsePoint = new Point(startPoint.X, startPoint.Y + height / 2);
            rightEllipsePoint = new Point(startPoint.X + width / 2, startPoint.Y + height / 2);
        }
        private string name;
        public string Name
        {
            get => name;
            set => name = value;
        }

        private bool isInterface;
        public bool IsInterface
        {
            get => isInterface;
            set => isInterface = value;
        }

        private string? stereotype;
        public string? Stereotype
        {
            get => stereotype;
            set => stereotype = value;
        }
        private string? visibility;
        public string? Visibility
        {
            get => visibility;
            set => visibility = value;
        }
        private ObservableCollection<DiagramElementAttribute> attributes;
        public ObservableCollection<DiagramElementAttribute> Attributes
        {
            get => attributes;
            set
            {
                this.SetAndRaise(ref attributes, value);
            } 
        }
        private ObservableCollection<DiagramElementOperation> operations;
        public ObservableCollection<DiagramElementOperation> Operations
        {
            get => operations;
            set => this.SetAndRaise(ref operations, value);
        }
        private Point startPoint;
        public Point StartPoint
        {
            get => startPoint;
            set => this.SetAndRaise(ref startPoint, value);
        }
        private int height;
        public int Height
        {
            get => height;
            set => this.SetAndRaise(ref height, value);
        }
        private int width;
        public int Width
        {
            get => width;
            set => this.SetAndRaise(ref width, value);
        }
        private Point leftEllipsePoint;
        public Point LeftEllipsePoint
        {
            get => leftEllipsePoint;
            set => this.SetAndRaise(ref leftEllipsePoint, value);
        }
        private Point rightEllipsePoint;
        public Point RightEllipsePoint
        {
            get => rightEllipsePoint;
            set => this.SetAndRaise(ref rightEllipsePoint, value);
        }
    }
}
