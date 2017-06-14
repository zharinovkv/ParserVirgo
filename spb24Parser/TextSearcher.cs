using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spb24Parser
{
    public class TextSearcher
    {
        // поле
        private string _text;

        // метка, которую ищем - индикатор, в каком месте фацла мы находимя
        private int _position;

        // конструктор
        public TextSearcher(string text)
        {
            _text = text;
        }

        // 39.00 будет возвращать метку, чтобы перейти к началу искомого текста
        public void GoTo(string text)
        {
            // 
            int p = _text.IndexOf(text, _position);
            if (p > -1)
                _position = p;
        }

        // чтобы найти нужный кусок кода в строке, прпустить часть кода, чтобы перейти к концу искомого текста
        // !!!! но у меня идет поиск куска текста неизвестной длины !!!
        public void Skip(string text)
        {
            int p = _text.IndexOf(text, _position);
            if (p > -1)
                _position = p + text.Length;
        }

        // метод будет чистать от текущней позиции до какой-то метки
        // если мы нашли позицию с данным текстом string text,
        // получаем подстроку                     text.Substring(_position, p);
        // и сдвигаем позицию на новое место      _position = p;
        // 46.00 - 47.30
        public string ReadTo(string text)
        {
            int p = _text.IndexOf(text, _position);

            string result = "";
            if (p > -1)
            {
                // от текущей позиции до найденной позиции
                result = _text.Substring(_position, p - _position);
                // текущую позицию делаем найденной
                _position = p;
            }

            //и вернем результат
            return result;

        }

        /** написав три метода 47.39, переходим в класс KinopoiskSearcher */
    }
}
