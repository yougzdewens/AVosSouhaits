using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVosSouhaits.HeritageEntities
{
    /// <summary>
    /// projet amelioré
    /// </summary>
    public class ProjetAmelio : Projet
    {
        /// <summary>
        /// Gets the civ1.
        /// </summary>
        /// <value>
        /// The civ1.
        /// </value>
        public string Civ1 { 
            get
            {
                switch (base.Civilite1)
                {
                    case 0:
                        return string.Format("Mr {0}", base.Nom1);
                    default:
                        return string.Format("Mlle {0}", base.Nom1);
                }
            }
        }

        /// <summary>
        /// Gets the civ2.
        /// </summary>
        /// <value>
        /// The civ2.
        /// </value>
        public string Civ2
        {
            get
            {
                switch (base.Civilite2)
                {
                    case 0:
                        return string.Format("Mr {0}", base.Nom2);
                    default:
                        return string.Format("Mlle {0}", base.Nom2);
                }
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProjetAmelio"/> class.
        /// </summary>
        /// <param name="p">The p.</param>
        public ProjetAmelio(Projet p)
        {
            base.Civilite1 = p.Civilite1;
            base.Civilite2 = p.Civilite2;
            base.Nom1 = p.Nom1;
            base.Nom2 = p.Nom2;
            base.Prenom1 = p.Prenom1;
            base.Prenom2 = p.Prenom2;
            base.Adresse = p.Adresse;
            base.CodePostal = p.CodePostal;
            base.Ville = p.Ville;
            base.IdProjet = p.IdProjet;
            base.Telephone = p.Telephone;
            base.DateDuMariage = p.DateDuMariage;
            base.Budget = p.Budget;
            base.Email = p.Email;
        }
    }
}
