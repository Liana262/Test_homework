using System;
using System.Collections.Generic;
using System.Text;

namespace TestProj_1
{
    /// <summary>
    /// Данные для создания записи
    /// </summary>
    public class NoteData
    {
        public NoteData(string text)
        {
            Text = text;
        }

        /// <summary>
        /// Основной текст заметки 
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// Ключевые слова, может быть несколько, но пока оставлю одно
        /// </summary>
        public string KeyTag { get; set; }
        /// <summary>
        /// Путь к картиночке, возможно адрес ссылки
        /// </summary>
        public string Pic { get; set; }

    }
}
