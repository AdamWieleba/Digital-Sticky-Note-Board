using System;

namespace DigitalStickyNoteBoard.Models
{
    public class Note
    {
        public Guid Id { get; set; }

        public string Title { get; set; } = "";

        public string Content { get; set; } = "";

        public double X { get; set; }

        public double Y { get; set; }

        public string Color { get; set; } = "#FFF59D";
    }
}
