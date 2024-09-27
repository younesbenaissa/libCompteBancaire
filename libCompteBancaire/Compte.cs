namespace libCompteBancaire
{
    public class Compte
    {
        // Attributs
        private int numero;                   // numéro unique
        private string proprietaire;          // nom du propriétaire
        private double solde;                 // montant restant sur le compte
        private double decouvertAutorise;     // montant du découvert autorisé (négatif)

        // Constructeur sans paramètre
        public Compte()
        {
            numero = 0;
            proprietaire = string.Empty;
            solde = 0.0;
            decouvertAutorise = 0.0;
        }

        // Constructeur avec paramètres
        public Compte(int numero, string proprietaire, double solde, double decouvertAutorise)
        {
            this.numero = numero;
            this.proprietaire = proprietaire;
            this.solde = solde;
            this.decouvertAutorise = decouvertAutorise;
        }

        // Accesseurs
        public int GetNumero()
        {
            return numero;
        }

        public string GetNom()
        {
            return proprietaire;
        }

        public double GetSolde()
        {
            return solde;
        }

        public double GetDecouvertAutorise()
        {
            return decouvertAutorise;
        }

        // Méthodes
        public void Crediter(double montant)
        {
            solde += montant;
        }

        public bool Debiter(double montant)
        {
            // Logique pour vérifier si le débit est possible
            if (solde - montant >= decouvertAutorise)
            {
                solde -= montant;
                return true;
            }
            return false;
        }

        public bool Transferer(double montant, Compte compteDest)
        {
            if (Debiter(montant))
            {
                compteDest.Crediter(montant);
                return true;
            }
            return false;
        }

        public bool Superieur(Compte compte)
        {
            return solde > compte.GetSolde();
        }

        public override string ToString()
        {
            return $"Compte {numero}, Propriétaire: {proprietaire}, Solde: {solde}, Découvert autorisé: {decouvertAutorise}";
        }
    }
}
