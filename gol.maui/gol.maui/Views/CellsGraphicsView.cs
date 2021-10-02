﻿using System;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;
using gol.maui.Extensions;

namespace gol.maui.Views
{
    public class CellsGraphicsView : GraphicsView
    {
        private readonly Action<(int row, int column)> _onCellLocationClickedAction;
        CellsDrawable _cellsDrawable;

        public CellsGraphicsView(Models.Cell[][] cells, Action<(int row, int column)> onCellLocationClicked)
        {
            _cellsDrawable = new CellsDrawable(cells);
            Drawable = _cellsDrawable;
            _onCellLocationClickedAction = onCellLocationClicked;

            this.AddClickHandler();
        }

        public void HandleClick(PointF clickLocation)
        {
            var clickResult = _cellsDrawable.CheckClickLocation(clickLocation);
            if(clickResult is null)
            {
                return;
            }

            _onCellLocationClickedAction?.Invoke(clickResult.Value);
        }
    }
}

