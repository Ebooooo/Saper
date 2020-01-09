using Saper.Data.Logics;
using Saper.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saper.Data.ViewModels
{
    public class GameViewModel : BaseViewModel
    {
        public GameViewModel()
        {

            Board = new Board(15, 10, 20);
        }
        /// <summary>
        /// Plansza
        /// </summary>
        public Board Board
        {
            get { return _Board; }
            set
            {
                _Board = value;
                OnPropertyChanged();
            }
        }
        private Board _Board;
        /// <summary>
        /// Comment
        /// </summary>
        public Command<Field> ShowCommand
        {
            get => new Command<Field>(field =>
            {
                BoardLogic logic = new BoardLogic();
                if (Board.IsEmpty)
                    logic.Fill(Board, field.X, field.Y);
                logic.Show(Board, field.X, field.Y);
            });
        }
        public Command<Field> CoverCommand { get; } = new Command<Field>(param =>
        {
            //param.Value = "Cover";
        });
    }
}
