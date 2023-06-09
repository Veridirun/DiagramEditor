﻿namespace DiagramEditor.Models.DiagramObjects
{
    public class DiagramElementOperation
    {
        private string name;
        public string Name
        {
            get => name;
            set => name = value;
        }
        private string type;
        public string Type
        {
            get => type;
            set => type = value;
        }
        private string visibility;
        public string Visibility
        {
            get => visibility;
            set => visibility = value;
        }
    }
}
