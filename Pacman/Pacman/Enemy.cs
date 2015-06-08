using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace Pacman
{
    class Enemy : SpriteObject
    {

        private Vector2 Position;
        public static Rectangle rectan;
        private path.Path pathen;
        private static path.Map map;
        public static void init()
        {
            map = new path.Map(22, 21);
            #region collision top
            map.getNodeAt(0, 0).Col = true;
            map.getNodeAt(1, 0).Col = true;
            map.getNodeAt(2, 0).Col = true;
            map.getNodeAt(3, 0).Col = true;
            map.getNodeAt(4, 0).Col = true;
            map.getNodeAt(5, 0).Col = true;
            map.getNodeAt(6, 0).Col = true;
            map.getNodeAt(7, 0).Col = true;
            map.getNodeAt(8, 0).Col = true;
            map.getNodeAt(9, 0).Col = true;
            map.getNodeAt(10, 0).Col = true;
            map.getNodeAt(11, 0).Col = true;
            map.getNodeAt(12, 0).Col = true;
            map.getNodeAt(13, 0).Col = true;
            map.getNodeAt(14, 0).Col = true;
            map.getNodeAt(15, 0).Col = true;
            map.getNodeAt(16, 0).Col = true;
            map.getNodeAt(17, 0).Col = true;
            map.getNodeAt(18, 0).Col = true;
            map.getNodeAt(19, 0).Col = true;
            map.getNodeAt(20, 0).Col = true;
            map.getNodeAt(21, 0).Col = true;
            #endregion
            #region collison layer 1
            map.getNodeAt(0, 1).Col = true;
            map.getNodeAt(1, 1).Col = false;
            map.getNodeAt(2, 1).Col = false;
            map.getNodeAt(3, 1).Col = false;
            map.getNodeAt(4, 1).Col = false;
            map.getNodeAt(5, 1).Col = false;
            map.getNodeAt(6, 1).Col = false;
            map.getNodeAt(7, 1).Col = false;
            map.getNodeAt(8, 1).Col = false;
            map.getNodeAt(9, 1).Col = false;
            map.getNodeAt(10, 1).Col = true;
            map.getNodeAt(11, 1).Col = false;
            map.getNodeAt(12, 1).Col = false;
            map.getNodeAt(13, 1).Col = false;
            map.getNodeAt(14, 1).Col = false;
            map.getNodeAt(15, 1).Col = false;
            map.getNodeAt(16, 1).Col = true;
            map.getNodeAt(17, 1).Col = true;
            map.getNodeAt(18, 1).Col = false;
            map.getNodeAt(19, 1).Col = false;
            map.getNodeAt(20, 1).Col = false;
            map.getNodeAt(21, 1).Col = true;
            #endregion
            #region collison layer 2
            map.getNodeAt(0, 2).Col = true;
            map.getNodeAt(1, 2).Col = false;
            map.getNodeAt(2, 2).Col = true;
            map.getNodeAt(3, 2).Col = true;
            map.getNodeAt(4, 2).Col = true;
            map.getNodeAt(5, 2).Col = true;
            map.getNodeAt(6, 2).Col = true;
            map.getNodeAt(7, 2).Col = true;
            map.getNodeAt(8, 2).Col = true;
            map.getNodeAt(9, 2).Col = false;
            map.getNodeAt(10, 2).Col = true;
            map.getNodeAt(11, 2).Col = false;
            map.getNodeAt(12, 2).Col = true;
            map.getNodeAt(13, 2).Col = false;
            map.getNodeAt(14, 2).Col = true;
            map.getNodeAt(15, 2).Col = false;
            map.getNodeAt(16, 2).Col = false;
            map.getNodeAt(17, 2).Col = false;
            map.getNodeAt(18, 2).Col = false;
            map.getNodeAt(19, 2).Col = true;
            map.getNodeAt(20, 2).Col = false;
            map.getNodeAt(21, 2).Col = true;
            #endregion
            #region collison layer 3
            map.getNodeAt(0, 3).Col = true;
            map.getNodeAt(1, 3).Col = false;
            map.getNodeAt(2, 3).Col = false;
            map.getNodeAt(3, 3).Col = false;
            map.getNodeAt(4, 3).Col = false;
            map.getNodeAt(5, 3).Col = false;
            map.getNodeAt(6, 3).Col = true;
            map.getNodeAt(7, 3).Col = false;
            map.getNodeAt(8, 3).Col = false;
            map.getNodeAt(9, 3).Col = false;
            map.getNodeAt(10, 3).Col = true;
            map.getNodeAt(11, 3).Col = false;
            map.getNodeAt(12, 3).Col = true;
            map.getNodeAt(13, 3).Col = false;
            map.getNodeAt(14, 3).Col = true;
            map.getNodeAt(15, 3).Col = true;
            map.getNodeAt(16, 3).Col = false;
            map.getNodeAt(17, 3).Col = true;
            map.getNodeAt(18, 3).Col = true;
            map.getNodeAt(19, 3).Col = true;
            map.getNodeAt(20, 3).Col = false;
            map.getNodeAt(21, 3).Col = true;
            #endregion
            #region collison layer 4
            map.getNodeAt(0, 4).Col = true;
            map.getNodeAt(1, 4).Col = false;
            map.getNodeAt(2, 4).Col = true;
            map.getNodeAt(3, 4).Col = false;
            map.getNodeAt(4, 4).Col = true;
            map.getNodeAt(5, 4).Col = false;
            map.getNodeAt(6, 4).Col = false;
            map.getNodeAt(7, 4).Col = false;
            map.getNodeAt(8, 4).Col = true;
            map.getNodeAt(9, 4).Col = false;
            map.getNodeAt(10, 4).Col = true;
            map.getNodeAt(11, 4).Col = false;
            map.getNodeAt(12, 4).Col = true;
            map.getNodeAt(13, 4).Col = false;
            map.getNodeAt(14, 4).Col = false;
            map.getNodeAt(15, 4).Col = true;
            map.getNodeAt(16, 4).Col = false;
            map.getNodeAt(17, 4).Col = true;
            map.getNodeAt(18, 4).Col = false;
            map.getNodeAt(19, 4).Col = false;
            map.getNodeAt(20, 4).Col = false;
            map.getNodeAt(21, 4).Col = true;
            #endregion
            #region collison layer 5
            map.getNodeAt(0, 5).Col = true;
            map.getNodeAt(1, 5).Col = false;
            map.getNodeAt(2, 5).Col = true;
            map.getNodeAt(3, 5).Col = false;
            map.getNodeAt(4, 5).Col = true;
            map.getNodeAt(5, 5).Col = true;
            map.getNodeAt(6, 5).Col = false;
            map.getNodeAt(7, 5).Col = true;
            map.getNodeAt(8, 5).Col = true;
            map.getNodeAt(9, 5).Col = false;
            map.getNodeAt(10, 5).Col = true;
            map.getNodeAt(11, 5).Col = false;
            map.getNodeAt(12, 5).Col = true;
            map.getNodeAt(13, 5).Col = true;
            map.getNodeAt(14, 5).Col = false;
            map.getNodeAt(15, 5).Col = true;
            map.getNodeAt(16, 5).Col = false;
            map.getNodeAt(17, 5).Col = true;
            map.getNodeAt(18, 5).Col = false;
            map.getNodeAt(19, 5).Col = true;
            map.getNodeAt(20, 5).Col = true;
            map.getNodeAt(21, 5).Col = true;
            #endregion
            #region collison layer 6
            map.getNodeAt(0, 6).Col = true;
            map.getNodeAt(1, 6).Col = false;
            map.getNodeAt(2, 6).Col = true;
            map.getNodeAt(3, 6).Col = false;
            map.getNodeAt(4, 6).Col = false;
            map.getNodeAt(5, 6).Col = false;
            map.getNodeAt(6, 6).Col = false;
            map.getNodeAt(7, 6).Col = false;
            map.getNodeAt(8, 6).Col = false;
            map.getNodeAt(9, 6).Col = false;
            map.getNodeAt(10, 6).Col = false;
            map.getNodeAt(11, 6).Col = false;
            map.getNodeAt(12, 6).Col = false;
            map.getNodeAt(13, 6).Col = false;
            map.getNodeAt(14, 6).Col = false;
            map.getNodeAt(15, 6).Col = true;
            map.getNodeAt(16, 6).Col = false;
            map.getNodeAt(17, 6).Col = true;
            map.getNodeAt(18, 6).Col = false;
            map.getNodeAt(19, 6).Col = false;
            map.getNodeAt(20, 6).Col = false;
            map.getNodeAt(21, 6).Col = true;
            #endregion
            #region collison layer 7
            map.getNodeAt(0, 7).Col = true;
            map.getNodeAt(1, 7).Col = false;
            map.getNodeAt(2, 7).Col = true;
            map.getNodeAt(3, 7).Col = true;
            map.getNodeAt(4, 7).Col = true;
            map.getNodeAt(5, 7).Col = true;
            map.getNodeAt(6, 7).Col = false;
            map.getNodeAt(7, 7).Col = true;
            map.getNodeAt(8, 7).Col = true;
            map.getNodeAt(9, 7).Col = true;
            map.getNodeAt(10, 7).Col = true;
            map.getNodeAt(11, 7).Col = false;
            map.getNodeAt(12, 7).Col = true;
            map.getNodeAt(13, 7).Col = true;
            map.getNodeAt(14, 7).Col = false;
            map.getNodeAt(15, 7).Col = true;
            map.getNodeAt(16, 7).Col = false;
            map.getNodeAt(17, 7).Col = true;
            map.getNodeAt(18, 7).Col = true;
            map.getNodeAt(19, 7).Col = true;
            map.getNodeAt(20, 7).Col = false;
            map.getNodeAt(21, 7).Col = true;
            #endregion
            #region collison layer 8
            map.getNodeAt(0, 8).Col = true;
            map.getNodeAt(1, 8).Col = false;
            map.getNodeAt(2, 8).Col = false;
            map.getNodeAt(3, 8).Col = false;
            map.getNodeAt(4, 8).Col = false;
            map.getNodeAt(5, 8).Col = false;
            map.getNodeAt(6, 8).Col = false;
            map.getNodeAt(7, 8).Col = false;
            map.getNodeAt(8, 8).Col = false;
            map.getNodeAt(9, 8).Col = false;
            map.getNodeAt(10, 8).Col = false;
            map.getNodeAt(11, 8).Col = false;
            map.getNodeAt(12, 8).Col = false;
            map.getNodeAt(13, 8).Col = false;
            map.getNodeAt(14, 8).Col = false;
            map.getNodeAt(15, 8).Col = false;
            map.getNodeAt(16, 8).Col = true;
            map.getNodeAt(17, 8).Col = true;
            map.getNodeAt(18, 8).Col = false;
            map.getNodeAt(19, 8).Col = false;
            map.getNodeAt(20, 8).Col = false;
            map.getNodeAt(21, 8).Col = true;
            #endregion
            #region collison layer 9
            map.getNodeAt(0, 9).Col = true;
            map.getNodeAt(1, 9).Col = true;
            map.getNodeAt(2, 9).Col = true;
            map.getNodeAt(3, 9).Col = true;
            map.getNodeAt(4, 9).Col = true;
            map.getNodeAt(5, 9).Col = false;
            map.getNodeAt(6, 9).Col = true;
            map.getNodeAt(7, 9).Col = true;
            map.getNodeAt(8, 9).Col = false;
            map.getNodeAt(9, 9).Col = true;
            map.getNodeAt(10, 9).Col = false;
            map.getNodeAt(11, 9).Col = false;
            map.getNodeAt(12, 9).Col = true;
            map.getNodeAt(13, 9).Col = false;
            map.getNodeAt(14, 9).Col = true;
            map.getNodeAt(15, 9).Col = true;
            map.getNodeAt(16, 9).Col = false;
            map.getNodeAt(17, 9).Col = false;
            map.getNodeAt(18, 9).Col = false;
            map.getNodeAt(19, 9).Col = true;
            map.getNodeAt(20, 9).Col = true;
            map.getNodeAt(21, 9).Col = true;
            #endregion
            #region collison layer 10
            map.getNodeAt(0, 10).Col = false;
            map.getNodeAt(1, 10).Col = false;
            map.getNodeAt(2, 10).Col = false;
            map.getNodeAt(3, 10).Col = false;
            map.getNodeAt(4, 10).Col = false;
            map.getNodeAt(5, 10).Col = false;
            map.getNodeAt(6, 10).Col = false;
            map.getNodeAt(7, 10).Col = false;
            map.getNodeAt(8, 10).Col = false;
            map.getNodeAt(9, 10).Col = true;
            map.getNodeAt(10, 10).Col = false;
            map.getNodeAt(11, 10).Col = false;
            map.getNodeAt(12, 10).Col = true;
            map.getNodeAt(13, 10).Col = false;
            map.getNodeAt(14, 10).Col = false;
            map.getNodeAt(15, 10).Col = false;
            map.getNodeAt(16, 10).Col = false;
            map.getNodeAt(17, 10).Col = true;
            map.getNodeAt(18, 10).Col = false;
            map.getNodeAt(19, 10).Col = false;
            map.getNodeAt(20, 10).Col = false;
            map.getNodeAt(21, 10).Col = false;
            #endregion
            #region collison layer 11
            map.getNodeAt(0, 11).Col = true;
            map.getNodeAt(1, 11).Col = false;
            map.getNodeAt(2, 11).Col = true;
            map.getNodeAt(3, 11).Col = true;
            map.getNodeAt(4, 11).Col = false;
            map.getNodeAt(5, 11).Col = true;
            map.getNodeAt(6, 11).Col = true;
            map.getNodeAt(7, 11).Col = true;
            map.getNodeAt(8, 11).Col = false;
            map.getNodeAt(9, 11).Col = true;
            map.getNodeAt(10, 11).Col = true;
            map.getNodeAt(11, 11).Col = true;
            map.getNodeAt(12, 11).Col = true;
            map.getNodeAt(13, 11).Col = false;
            map.getNodeAt(14, 11).Col = true;
            map.getNodeAt(15, 11).Col = true;
            map.getNodeAt(16, 11).Col = true;
            map.getNodeAt(17, 11).Col = true;
            map.getNodeAt(18, 11).Col = true;
            map.getNodeAt(19, 11).Col = true;
            map.getNodeAt(20, 11).Col = true;
            map.getNodeAt(21, 11).Col = true;
            #endregion
            #region collison layer 12
            map.getNodeAt(0, 12).Col = true;
            map.getNodeAt(1, 12).Col = false;
            map.getNodeAt(2, 12).Col = true;
            map.getNodeAt(3, 12).Col = true;
            map.getNodeAt(4, 12).Col = false;
            map.getNodeAt(5, 12).Col = false;
            map.getNodeAt(6, 12).Col = false;
            map.getNodeAt(7, 12).Col = false;
            map.getNodeAt(8, 12).Col = false;
            map.getNodeAt(9, 12).Col = false;
            map.getNodeAt(10, 12).Col = false;
            map.getNodeAt(11, 12).Col = false;
            map.getNodeAt(12, 12).Col = false;
            map.getNodeAt(13, 12).Col = false;
            map.getNodeAt(14, 12).Col = false;
            map.getNodeAt(15, 12).Col = false;
            map.getNodeAt(16, 12).Col = false;
            map.getNodeAt(17, 12).Col = false;
            map.getNodeAt(18, 12).Col = false;
            map.getNodeAt(19, 12).Col = false;
            map.getNodeAt(20, 12).Col = false;
            map.getNodeAt(21, 12).Col = true;
            #endregion
            #region collison layer 13
            map.getNodeAt(0, 13).Col = true;
            map.getNodeAt(1, 13).Col = false;
            map.getNodeAt(2, 13).Col = false;
            map.getNodeAt(3, 13).Col = true;
            map.getNodeAt(4, 13).Col = true;
            map.getNodeAt(5, 13).Col = true;
            map.getNodeAt(6, 13).Col = true;
            map.getNodeAt(7, 13).Col = true;
            map.getNodeAt(8, 13).Col = true;
            map.getNodeAt(9, 13).Col = false;
            map.getNodeAt(10, 13).Col = true;
            map.getNodeAt(11, 13).Col = true;
            map.getNodeAt(12, 13).Col = true;
            map.getNodeAt(13, 13).Col = true;
            map.getNodeAt(14, 13).Col = false;
            map.getNodeAt(15, 13).Col = true;
            map.getNodeAt(16, 13).Col = false;
            map.getNodeAt(17, 13).Col = true;
            map.getNodeAt(18, 13).Col = true;
            map.getNodeAt(19, 13).Col = true;
            map.getNodeAt(20, 13).Col = false;
            map.getNodeAt(21, 13).Col = true;
            #endregion
            #region collison layer 14
            map.getNodeAt(0, 14).Col = true;
            map.getNodeAt(1, 14).Col = true;
            map.getNodeAt(2, 14).Col = false;
            map.getNodeAt(3, 14).Col = true;
            map.getNodeAt(4, 14).Col = false;
            map.getNodeAt(5, 14).Col = false;
            map.getNodeAt(6, 14).Col = false;
            map.getNodeAt(7, 14).Col = false;
            map.getNodeAt(8, 14).Col = false;
            map.getNodeAt(9, 14).Col = false;
            map.getNodeAt(10, 14).Col = true;
            map.getNodeAt(11, 14).Col = false;
            map.getNodeAt(12, 14).Col = false;
            map.getNodeAt(13, 14).Col = false;
            map.getNodeAt(14, 14).Col = false;
            map.getNodeAt(15, 14).Col = true;
            map.getNodeAt(16, 14).Col = false;
            map.getNodeAt(17, 14).Col = false;
            map.getNodeAt(18, 14).Col = false;
            map.getNodeAt(19, 14).Col = true;
            map.getNodeAt(20, 14).Col = false;
            map.getNodeAt(21, 14).Col = true;
            #endregion
            #region collison layer 15
            map.getNodeAt(0, 15).Col = true;
            map.getNodeAt(1, 15).Col = false;
            map.getNodeAt(2, 15).Col = false;
            map.getNodeAt(3, 15).Col = true;
            map.getNodeAt(4, 15).Col = false;
            map.getNodeAt(5, 15).Col = true;
            map.getNodeAt(6, 15).Col = true;
            map.getNodeAt(7, 15).Col = true;
            map.getNodeAt(8, 15).Col = true;
            map.getNodeAt(9, 15).Col = false;
            map.getNodeAt(10, 15).Col = true;
            map.getNodeAt(11, 15).Col = false;
            map.getNodeAt(12, 15).Col = true;
            map.getNodeAt(13, 15).Col = true;
            map.getNodeAt(14, 15).Col = true;
            map.getNodeAt(15, 15).Col = true;
            map.getNodeAt(16, 15).Col = true;
            map.getNodeAt(17, 15).Col = true;
            map.getNodeAt(18, 15).Col = false;
            map.getNodeAt(19, 15).Col = true;
            map.getNodeAt(20, 15).Col = false;
            map.getNodeAt(21, 15).Col = true;
            #endregion
            #region collison layer 16
            map.getNodeAt(0, 16).Col = true;
            map.getNodeAt(1, 16).Col = false;
            map.getNodeAt(2, 16).Col = true;
            map.getNodeAt(3, 16).Col = true;
            map.getNodeAt(4, 16).Col = false;
            map.getNodeAt(5, 16).Col = true;
            map.getNodeAt(6, 16).Col = false;
            map.getNodeAt(7, 16).Col = false;
            map.getNodeAt(8, 16).Col = false;
            map.getNodeAt(9, 16).Col = false;
            map.getNodeAt(10, 16).Col = true;
            map.getNodeAt(11, 16).Col = false;
            map.getNodeAt(12, 16).Col = false;
            map.getNodeAt(13, 16).Col = false;
            map.getNodeAt(14, 16).Col = false;
            map.getNodeAt(15, 16).Col = false;
            map.getNodeAt(16, 16).Col = false;
            map.getNodeAt(17, 16).Col = true;
            map.getNodeAt(18, 16).Col = false;
            map.getNodeAt(19, 16).Col = true;
            map.getNodeAt(20, 16).Col = false;
            map.getNodeAt(21, 16).Col = true;
            #endregion
            #region collison layer 17
            map.getNodeAt(0, 17).Col = true;
            map.getNodeAt(1, 17).Col = false;
            map.getNodeAt(2, 17).Col = false;
            map.getNodeAt(3, 17).Col = true;
            map.getNodeAt(4, 17).Col = false;
            map.getNodeAt(5, 17).Col = true;
            map.getNodeAt(6, 17).Col = false;
            map.getNodeAt(7, 17).Col = true;
            map.getNodeAt(8, 17).Col = true;
            map.getNodeAt(9, 17).Col = true;
            map.getNodeAt(10, 17).Col = true;
            map.getNodeAt(11, 17).Col = true;
            map.getNodeAt(12, 17).Col = true;
            map.getNodeAt(13, 17).Col = true;
            map.getNodeAt(14, 17).Col = true;
            map.getNodeAt(15, 17).Col = true;
            map.getNodeAt(16, 17).Col = false;
            map.getNodeAt(17, 17).Col = true;
            map.getNodeAt(18, 17).Col = false;
            map.getNodeAt(19, 17).Col = false;
            map.getNodeAt(20, 17).Col = false;
            map.getNodeAt(21, 17).Col = true;
            #endregion
            #region collison layer 18
            map.getNodeAt(0, 18).Col = true;
            map.getNodeAt(1, 18).Col = true;
            map.getNodeAt(2, 18).Col = false;
            map.getNodeAt(3, 18).Col = true;
            map.getNodeAt(4, 18).Col = false;
            map.getNodeAt(5, 18).Col = true;
            map.getNodeAt(6, 18).Col = false;
            map.getNodeAt(7, 18).Col = true;
            map.getNodeAt(8, 18).Col = false;
            map.getNodeAt(9, 18).Col = false;
            map.getNodeAt(10, 18).Col = false;
            map.getNodeAt(11, 18).Col = true;
            map.getNodeAt(12, 18).Col = false;
            map.getNodeAt(13, 18).Col = false;
            map.getNodeAt(14, 18).Col = false;
            map.getNodeAt(15, 18).Col = true;
            map.getNodeAt(16, 18).Col = false;
            map.getNodeAt(17, 18).Col = true;
            map.getNodeAt(18, 18).Col = true;
            map.getNodeAt(19, 18).Col = true;
            map.getNodeAt(20, 18).Col = false;
            map.getNodeAt(21, 18).Col = true;
            #endregion
            #region collison layer 19
            map.getNodeAt(0, 19).Col = true;
            map.getNodeAt(1, 19).Col = false;
            map.getNodeAt(2, 19).Col = false;
            map.getNodeAt(3, 19).Col = false;
            map.getNodeAt(4, 19).Col = false;
            map.getNodeAt(5, 19).Col = true;
            map.getNodeAt(6, 19).Col = false;
            map.getNodeAt(7, 19).Col = false;
            map.getNodeAt(8, 19).Col = false;
            map.getNodeAt(9, 19).Col = true;
            map.getNodeAt(10, 19).Col = false;
            map.getNodeAt(11, 19).Col = false;
            map.getNodeAt(12, 19).Col = false;
            map.getNodeAt(13, 19).Col = true;
            map.getNodeAt(14, 19).Col = false;
            map.getNodeAt(15, 19).Col = false;
            map.getNodeAt(16, 19).Col = false;
            map.getNodeAt(17, 19).Col = false;
            map.getNodeAt(18, 19).Col = false;
            map.getNodeAt(19, 19).Col = false;
            map.getNodeAt(20, 19).Col = false;
            map.getNodeAt(21, 19).Col = true;
            #endregion
            #region collison layer 20
            map.getNodeAt(0, 20).Col = true;
            map.getNodeAt(1, 20).Col = true;
            map.getNodeAt(2, 20).Col = true;
            map.getNodeAt(3, 20).Col = true;
            map.getNodeAt(4, 20).Col = true;
            map.getNodeAt(5, 20).Col = true;
            map.getNodeAt(6, 20).Col = true;
            map.getNodeAt(7, 20).Col = true;
            map.getNodeAt(8, 20).Col = true;
            map.getNodeAt(9, 20).Col = true;
            map.getNodeAt(10, 20).Col = true;
            map.getNodeAt(11, 20).Col = true;
            map.getNodeAt(12, 20).Col = true;
            map.getNodeAt(13, 20).Col = true;
            map.getNodeAt(14, 20).Col = true;
            map.getNodeAt(15, 20).Col = true;
            map.getNodeAt(16, 20).Col = true;
            map.getNodeAt(17, 20).Col = true;
            map.getNodeAt(18, 20).Col = true;
            map.getNodeAt(19, 20).Col = true;
            map.getNodeAt(20, 20).Col = true;
            map.getNodeAt(21, 20).Col = true;
            #endregion
        }



        public Enemy(Vector2 pos, int player)
            : base(pos)
        {
            CreateAnimation("MoveRight", 5, 0, 0, 32, 32, new Vector2(0, 0), 5);
            CreateAnimation("MoveLeft", 5, 65, 0, 65, 65, new Vector2(0, 0), 5);
            CreateAnimation("DmgRight", 4, 185, 0, 65, 65, new Vector2(0, 0), 5);
            CreateAnimation("DmgLeft", 5, 185, 0, 65, 65, new Vector2(0, 0), 5);
            CreateAnimation("Explode", 5, 260, 0, 100, 100, new Vector2(-10, -10), 5);
            PlayAnimation("MoveRight");

            Position = pos;

        }
        public override void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>(@"card");

            base.LoadContent(content);
        }
        private void ChasePlayer()
        {


        }
        public override void Update(GameTime gameTime)
        {
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (pathen != null)
            {
                Vector2 dir = pathen.Target - position;
                float distance = dir.Length();
                float step = speed * deltaTime;

                if (distance < step)
                {
                    position = pathen.Target;
                    if (!pathen.Next())
                    {
                        pathen = null;
                    }
                }
                else
                {
                    dir.Normalize();
                    position += dir * step;
                }
            }
            else
            {
                path.Node start = map.getNodeAt(position);
                path.Node goal = map.getNodeAt(GameWorld.Player.position);

                pathen = map.findPath(start, goal);
            }

            rectan = CollisionRect;
            if (Player.isPower == false)
            {

            }



            if (CollisionRect.Intersects((Player.rectan)))
            {
                if (Player.isPower == true)
                {
                    position = new Vector2(100, 100);
                }

            }
            
            //position += (velocity * deltaTime);

            base.Update(gameTime);
        }
    }
}

