using DigitalStickyNoteBoard.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace DigitalStickyNoteBoard.Services
{
    public class NoteStorageService
    {
        private readonly string _filePath;

        private readonly JsonSerializerOptions _jsonOptions = new()
        {
            WriteIndented = true
        };

        public NoteStorageService()
        {
            string dataDirectory = Path.Combine(
                AppContext.BaseDirectory,
                "Data");

            Directory.CreateDirectory(dataDirectory);

            _filePath = Path.Combine(
                dataDirectory,
                "notes.json");
        }

        public List<Note> Load()
        {
            if (!File.Exists(_filePath))
                return new List<Note>();

            try
            {
                string json = File.ReadAllText(_filePath);

                return JsonSerializer.Deserialize<List<Note>>(
                    json,
                    _jsonOptions) ?? new List<Note>();
            }
            catch (JsonException)
            {
                return new List<Note>();
            }
        }

        public void Save(IEnumerable<Note> notes)
        {
            string json = JsonSerializer.Serialize(
                notes,
                _jsonOptions);

            File.WriteAllText(_filePath, json);
        }
    }
}
