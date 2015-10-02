using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVosSouhaits.HeritageEntities
{
    public class ProjetAmelio : Projet
    {

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
