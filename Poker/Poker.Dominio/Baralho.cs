﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Poker.Dominio
{
    public class Baralho
    {
        public Baralho()
        {
            Cartas = new List<Carta>();
            Montar();
        }
        public List<Carta> Cartas { get; set; }

        private void Montar()
        {
            foreach (var naipe in Enum.GetValues(typeof(Naipe)).Cast<Naipe>())
            {
                foreach (var face in Enum.GetValues(typeof(Face)).Cast<Face>())
                {
                    Cartas.Add(new Carta(face, naipe));
                }
            }
        }
    }
}