using BlazQuizz.Domain;
using Microsoft.AspNetCore.Components;
using System;
using System.Net;

namespace BlazQuizz.Components.Shared
{
    public partial class QuizzCard
    {
        [Parameter]
        public Questions? CurrentQuestion { get; set; }
        [Parameter]
        public int? NumQuestion { get; set; }
        [Parameter]
        public EventCallback OnResponse { get; set; }

        public List<Proposition> Propositions { get; set; }

        protected override Task OnParametersSetAsync()
        {
            LoadPropositions();
            return base.OnParametersSetAsync();
        }



        //protected override Task OnInitializedAsync()
        //{
        //    LoadPropositions();
        //    return base.OnInitializedAsync();
        //}
        private void LoadPropositions()
        {
            List<Proposition> temporaire = new List<Proposition>();
            temporaire.Add(new Proposition { IsCorrect = true, Reponse = CurrentQuestion.Answer });

            for (int i = 0; i < CurrentQuestion.BadAnswer.Count; i++)
            {
                temporaire.Add(new Proposition { IsCorrect = false, Reponse = CurrentQuestion.BadAnswer[i] });
            }

            //Mélanger
            Shuffle(temporaire.ToArray());
            //Attribuer la lettre de la question
            for (int i = 0; i < temporaire.Count; i++)
            {
                temporaire[i].Letter = NumberToLetter(i + 1);
            }
            Propositions = [.. temporaire];
        }
        public void Choix(Proposition rep)
        {
            if (CurrentQuestion != null)
            {
                CurrentQuestion.Reponse = rep;
                OnResponse.InvokeAsync();
            }
        }

        /// <summary>
        /// Convertit un nombre en lettres de l'alphabet (1=A, 2=B, ..., 26=Z, 27=AA, 28=AB, etc.)
        /// Fonctionne comme la numérotation des colonnes Excel
        /// </summary>
        /// <param name="number">Le nombre à convertir (doit être positif)</param>
        /// <returns>La ou les lettres correspondantes en majuscule</returns>
        private string NumberToLetter(int number)
        {
            if (number < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(number),
                    "Le nombre doit être positif.");
            }

            string result = "";

            while (number > 0)
            {
                number--; // Ajustement pour base 0
                result = (char)('A' + (number % 26)) + result;
                number /= 26;
            }

            return result;
        }
        private static readonly Random _random = new Random();
        private void Shuffle<T>(T[] array)
        {
            if (array == null || array.Length <= 1) return;

            // Algorithme Fisher-Yates (shuffle moderne)
            for (int i = array.Length - 1; i > 0; i--)
            {
                int j = _random.Next(i + 1);

                // Échange des éléments
                T temp = array[i];
                array[i] = array[j];
                array[j] = temp;
            }
        }

    }
}
