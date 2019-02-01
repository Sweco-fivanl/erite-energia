using System;

namespace EriteEnergia
{

    // NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://schemas.xmlsoap.org/soap/envelope/", IsNullable = false)]
    public partial class Envelope
    {

        private EnvelopeBody bodyField;

        /// <remarks/>
        public EnvelopeBody Body
        {
            get
            {
                return this.bodyField;
            }
            set
            {
                this.bodyField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
    public partial class EnvelopeBody
    {

        private EnergiatodistusIlmoitus energiatodistusIlmoitusField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.energiatodistusrekisteri.fi/ws/energiatodistustypes")]
        public EnergiatodistusIlmoitus EnergiatodistusIlmoitus
        {
            get
            {
                return this.energiatodistusIlmoitusField;
            }
            set
            {
                this.energiatodistusIlmoitusField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.energiatodistusrekisteri.fi/ws/energiatodistustypes")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.energiatodistusrekisteri.fi/ws/energiatodistustypes", IsNullable = false)]
    public partial class EnergiatodistusIlmoitus
    {

        private EnergiatodistusIlmoitusEnergiatodistus energiatodistusField;

        /// <remarks/>
        public EnergiatodistusIlmoitusEnergiatodistus Energiatodistus
        {
            get
            {
                return this.energiatodistusField;
            }
            set
            {
                this.energiatodistusField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.energiatodistusrekisteri.fi/ws/energiatodistustypes")]
    public partial class EnergiatodistusIlmoitusEnergiatodistus
    {

        private EnergiatodistusIlmoitusEnergiatodistusPerustiedot perustiedotField;

        private EnergiatodistusIlmoitusEnergiatodistusLahtotiedot lahtotiedotField;

        private EnergiatodistusIlmoitusEnergiatodistusTulokset tuloksetField;

        private EnergiatodistusIlmoitusEnergiatodistusToteutunutOstoenergiankulutus toteutunutOstoenergiankulutusField;

        private EnergiatodistusIlmoitusEnergiatodistusHuomiot huomiotField;

        private string lisamerkintoja_FiField;

        private string lisamerkintoja_SvField;

        /// <remarks/>
        public EnergiatodistusIlmoitusEnergiatodistusPerustiedot Perustiedot
        {
            get
            {
                return this.perustiedotField;
            }
            set
            {
                this.perustiedotField = value;
            }
        }

        /// <remarks/>
        public EnergiatodistusIlmoitusEnergiatodistusLahtotiedot Lahtotiedot
        {
            get
            {
                return this.lahtotiedotField;
            }
            set
            {
                this.lahtotiedotField = value;
            }
        }

        /// <remarks/>
        public EnergiatodistusIlmoitusEnergiatodistusTulokset Tulokset
        {
            get
            {
                return this.tuloksetField;
            }
            set
            {
                this.tuloksetField = value;
            }
        }

        /// <remarks/>
        public EnergiatodistusIlmoitusEnergiatodistusToteutunutOstoenergiankulutus ToteutunutOstoenergiankulutus
        {
            get
            {
                return this.toteutunutOstoenergiankulutusField;
            }
            set
            {
                this.toteutunutOstoenergiankulutusField = value;
            }
        }

        /// <remarks/>
        public EnergiatodistusIlmoitusEnergiatodistusHuomiot Huomiot
        {
            get
            {
                return this.huomiotField;
            }
            set
            {
                this.huomiotField = value;
            }
        }

        /// <remarks/>
        public string Lisamerkintoja_Fi
        {
            get
            {
                return this.lisamerkintoja_FiField;
            }
            set
            {
                this.lisamerkintoja_FiField = value;
            }
        }

        /// <remarks/>
        public string Lisamerkintoja_Sv
        {
            get
            {
                return this.lisamerkintoja_SvField;
            }
            set
            {
                this.lisamerkintoja_SvField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.energiatodistusrekisteri.fi/ws/energiatodistustypes")]
    public partial class EnergiatodistusIlmoitusEnergiatodistusPerustiedot
    {

        private string nimiField;

        private string rakennustunnusField;

        private string katuosoite_FiField;

        private string katuosoite_SvField;

        private byte postinumeroField;

        private bool onkoJulkinenRakennusField;

        private bool onkoUudisrakennusField;

        private string rakennusosaField;

        private ushort valmistumisvuosiField;

        private string kayttotarkoitusField;

        private byte kieliField;

        private string tilaajaField;

        private EnergiatodistusIlmoitusEnergiatodistusPerustiedotYritys yritysField;

        private string keskeisetSuositukset_FiField;

        private string keskeisetSuositukset_SvField;

        /// <remarks/>
        public string Nimi
        {
            get
            {
                return this.nimiField;
            }
            set
            {
                this.nimiField = value;
            }
        }

        /// <remarks/>
        public string Rakennustunnus
        {
            get
            {
                return this.rakennustunnusField;
            }
            set
            {
                this.rakennustunnusField = value;
            }
        }

        /// <remarks/>
        public string Katuosoite_Fi
        {
            get
            {
                return this.katuosoite_FiField;
            }
            set
            {
                this.katuosoite_FiField = value;
            }
        }

        /// <remarks/>
        public string Katuosoite_Sv
        {
            get
            {
                return this.katuosoite_SvField;
            }
            set
            {
                this.katuosoite_SvField = value;
            }
        }

        /// <remarks/>
        public byte Postinumero
        {
            get
            {
                return this.postinumeroField;
            }
            set
            {
                this.postinumeroField = value;
            }
        }

        /// <remarks/>
        public bool OnkoJulkinenRakennus
        {
            get
            {
                return this.onkoJulkinenRakennusField;
            }
            set
            {
                this.onkoJulkinenRakennusField = value;
            }
        }

        /// <remarks/>
        public bool OnkoUudisrakennus
        {
            get
            {
                return this.onkoUudisrakennusField;
            }
            set
            {
                this.onkoUudisrakennusField = value;
            }
        }

        /// <remarks/>
        public string Rakennusosa
        {
            get
            {
                return this.rakennusosaField;
            }
            set
            {
                this.rakennusosaField = value;
            }
        }

        /// <remarks/>
        public ushort Valmistumisvuosi
        {
            get
            {
                return this.valmistumisvuosiField;
            }
            set
            {
                this.valmistumisvuosiField = value;
            }
        }

        /// <remarks/>
        public string Kayttotarkoitus
        {
            get
            {
                return this.kayttotarkoitusField;
            }
            set
            {
                this.kayttotarkoitusField = value;
            }
        }

        /// <remarks/>
        public byte Kieli
        {
            get
            {
                return this.kieliField;
            }
            set
            {
                this.kieliField = value;
            }
        }

        /// <remarks/>
        public string Tilaaja
        {
            get
            {
                return this.tilaajaField;
            }
            set
            {
                this.tilaajaField = value;
            }
        }

        /// <remarks/>
        public EnergiatodistusIlmoitusEnergiatodistusPerustiedotYritys Yritys
        {
            get
            {
                return this.yritysField;
            }
            set
            {
                this.yritysField = value;
            }
        }

        /// <remarks/>
        public string KeskeisetSuositukset_Fi
        {
            get
            {
                return this.keskeisetSuositukset_FiField;
            }
            set
            {
                this.keskeisetSuositukset_FiField = value;
            }
        }

        /// <remarks/>
        public string KeskeisetSuositukset_Sv
        {
            get
            {
                return this.keskeisetSuositukset_SvField;
            }
            set
            {
                this.keskeisetSuositukset_SvField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.energiatodistusrekisteri.fi/ws/energiatodistustypes")]
    public partial class EnergiatodistusIlmoitusEnergiatodistusPerustiedotYritys
    {

        private string nimiField;

        private string katuosoiteField;

        private byte postinumeroField;

        /// <remarks/>
        public string Nimi
        {
            get
            {
                return this.nimiField;
            }
            set
            {
                this.nimiField = value;
            }
        }

        /// <remarks/>
        public string Katuosoite
        {
            get
            {
                return this.katuosoiteField;
            }
            set
            {
                this.katuosoiteField = value;
            }
        }

        /// <remarks/>
        public byte Postinumero
        {
            get
            {
                return this.postinumeroField;
            }
            set
            {
                this.postinumeroField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.energiatodistusrekisteri.fi/ws/energiatodistustypes")]
    public partial class EnergiatodistusIlmoitusEnergiatodistusLahtotiedot
    {

        private decimal lammitettyNettoalaField;

        private EnergiatodistusIlmoitusEnergiatodistusLahtotiedotLahtotiedotRakennusvaippa lahtotiedotRakennusvaippaField;

        private EnergiatodistusIlmoitusEnergiatodistusLahtotiedotLahtotiedotIkkunat lahtotiedotIkkunatField;

        private EnergiatodistusIlmoitusEnergiatodistusLahtotiedotLahtotiedotIlmanvaihto lahtotiedotIlmanvaihtoField;

        private EnergiatodistusIlmoitusEnergiatodistusLahtotiedotLahtotiedotLammitys lahtotiedotLammitysField;

        private EnergiatodistusIlmoitusEnergiatodistusLahtotiedotLahtotiedotJaahdytysjarjestelma lahtotiedotJaahdytysjarjestelmaField;

        private EnergiatodistusIlmoitusEnergiatodistusLahtotiedotLahtotiedotLkvnKaytto lahtotiedotLkvnKayttoField;

        private EnergiatodistusIlmoitusEnergiatodistusLahtotiedotSisKuorma[] lahtotiedotSisKuormatField;

        /// <remarks/>
        public decimal LammitettyNettoala
        {
            get
            {
                return this.lammitettyNettoalaField;
            }
            set
            {
                this.lammitettyNettoalaField = value;
            }
        }

        /// <remarks/>
        public EnergiatodistusIlmoitusEnergiatodistusLahtotiedotLahtotiedotRakennusvaippa LahtotiedotRakennusvaippa
        {
            get
            {
                return this.lahtotiedotRakennusvaippaField;
            }
            set
            {
                this.lahtotiedotRakennusvaippaField = value;
            }
        }

        /// <remarks/>
        public EnergiatodistusIlmoitusEnergiatodistusLahtotiedotLahtotiedotIkkunat LahtotiedotIkkunat
        {
            get
            {
                return this.lahtotiedotIkkunatField;
            }
            set
            {
                this.lahtotiedotIkkunatField = value;
            }
        }

        /// <remarks/>
        public EnergiatodistusIlmoitusEnergiatodistusLahtotiedotLahtotiedotIlmanvaihto LahtotiedotIlmanvaihto
        {
            get
            {
                return this.lahtotiedotIlmanvaihtoField;
            }
            set
            {
                this.lahtotiedotIlmanvaihtoField = value;
            }
        }

        /// <remarks/>
        public EnergiatodistusIlmoitusEnergiatodistusLahtotiedotLahtotiedotLammitys LahtotiedotLammitys
        {
            get
            {
                return this.lahtotiedotLammitysField;
            }
            set
            {
                this.lahtotiedotLammitysField = value;
            }
        }

        /// <remarks/>
        public EnergiatodistusIlmoitusEnergiatodistusLahtotiedotLahtotiedotJaahdytysjarjestelma LahtotiedotJaahdytysjarjestelma
        {
            get
            {
                return this.lahtotiedotJaahdytysjarjestelmaField;
            }
            set
            {
                this.lahtotiedotJaahdytysjarjestelmaField = value;
            }
        }

        /// <remarks/>
        public EnergiatodistusIlmoitusEnergiatodistusLahtotiedotLahtotiedotLkvnKaytto LahtotiedotLkvnKaytto
        {
            get
            {
                return this.lahtotiedotLkvnKayttoField;
            }
            set
            {
                this.lahtotiedotLkvnKayttoField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("SisKuorma", IsNullable = false)]
        public EnergiatodistusIlmoitusEnergiatodistusLahtotiedotSisKuorma[] LahtotiedotSisKuormat
        {
            get
            {
                return this.lahtotiedotSisKuormatField;
            }
            set
            {
                this.lahtotiedotSisKuormatField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.energiatodistusrekisteri.fi/ws/energiatodistustypes")]
    public partial class EnergiatodistusIlmoitusEnergiatodistusLahtotiedotLahtotiedotRakennusvaippa
    {

        private decimal ilmanvuotolukuField;

        private EnergiatodistusIlmoitusEnergiatodistusLahtotiedotLahtotiedotRakennusvaippaRvUlkoseinat rvUlkoseinatField;

        private EnergiatodistusIlmoitusEnergiatodistusLahtotiedotLahtotiedotRakennusvaippaRvYlapohja rvYlapohjaField;

        private EnergiatodistusIlmoitusEnergiatodistusLahtotiedotLahtotiedotRakennusvaippaRvAlapohja rvAlapohjaField;

        private EnergiatodistusIlmoitusEnergiatodistusLahtotiedotLahtotiedotRakennusvaippaRvIkkunat rvIkkunatField;

        private EnergiatodistusIlmoitusEnergiatodistusLahtotiedotLahtotiedotRakennusvaippaRvUlkoovet rvUlkoovetField;

        private decimal rvKylmasillatUAField;

        /// <remarks/>
        public decimal Ilmanvuotoluku
        {
            get
            {
                return this.ilmanvuotolukuField;
            }
            set
            {
                this.ilmanvuotolukuField = value;
            }
        }

        /// <remarks/>
        public EnergiatodistusIlmoitusEnergiatodistusLahtotiedotLahtotiedotRakennusvaippaRvUlkoseinat RvUlkoseinat
        {
            get
            {
                return this.rvUlkoseinatField;
            }
            set
            {
                this.rvUlkoseinatField = value;
            }
        }

        /// <remarks/>
        public EnergiatodistusIlmoitusEnergiatodistusLahtotiedotLahtotiedotRakennusvaippaRvYlapohja RvYlapohja
        {
            get
            {
                return this.rvYlapohjaField;
            }
            set
            {
                this.rvYlapohjaField = value;
            }
        }

        /// <remarks/>
        public EnergiatodistusIlmoitusEnergiatodistusLahtotiedotLahtotiedotRakennusvaippaRvAlapohja RvAlapohja
        {
            get
            {
                return this.rvAlapohjaField;
            }
            set
            {
                this.rvAlapohjaField = value;
            }
        }

        /// <remarks/>
        public EnergiatodistusIlmoitusEnergiatodistusLahtotiedotLahtotiedotRakennusvaippaRvIkkunat RvIkkunat
        {
            get
            {
                return this.rvIkkunatField;
            }
            set
            {
                this.rvIkkunatField = value;
            }
        }

        /// <remarks/>
        public EnergiatodistusIlmoitusEnergiatodistusLahtotiedotLahtotiedotRakennusvaippaRvUlkoovet RvUlkoovet
        {
            get
            {
                return this.rvUlkoovetField;
            }
            set
            {
                this.rvUlkoovetField = value;
            }
        }

        /// <remarks/>
        public decimal RvKylmasillatUA
        {
            get
            {
                return this.rvKylmasillatUAField;
            }
            set
            {
                this.rvKylmasillatUAField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.energiatodistusrekisteri.fi/ws/energiatodistustypes")]
    public partial class EnergiatodistusIlmoitusEnergiatodistusLahtotiedotLahtotiedotRakennusvaippaRvUlkoseinat
    {

        private decimal rvAField;

        private decimal rvUField;

        /// <remarks/>
        public decimal RvA
        {
            get
            {
                return this.rvAField;
            }
            set
            {
                this.rvAField = value;
            }
        }

        /// <remarks/>
        public decimal RvU
        {
            get
            {
                return this.rvUField;
            }
            set
            {
                this.rvUField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.energiatodistusrekisteri.fi/ws/energiatodistustypes")]
    public partial class EnergiatodistusIlmoitusEnergiatodistusLahtotiedotLahtotiedotRakennusvaippaRvYlapohja
    {

        private decimal rvAField;

        private decimal rvUField;

        /// <remarks/>
        public decimal RvA
        {
            get
            {
                return this.rvAField;
            }
            set
            {
                this.rvAField = value;
            }
        }

        /// <remarks/>
        public decimal RvU
        {
            get
            {
                return this.rvUField;
            }
            set
            {
                this.rvUField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.energiatodistusrekisteri.fi/ws/energiatodistustypes")]
    public partial class EnergiatodistusIlmoitusEnergiatodistusLahtotiedotLahtotiedotRakennusvaippaRvAlapohja
    {

        private decimal rvAField;

        private decimal rvUField;

        /// <remarks/>
        public decimal RvA
        {
            get
            {
                return this.rvAField;
            }
            set
            {
                this.rvAField = value;
            }
        }

        /// <remarks/>
        public decimal RvU
        {
            get
            {
                return this.rvUField;
            }
            set
            {
                this.rvUField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.energiatodistusrekisteri.fi/ws/energiatodistustypes")]
    public partial class EnergiatodistusIlmoitusEnergiatodistusLahtotiedotLahtotiedotRakennusvaippaRvIkkunat
    {

        private decimal rvAField;

        private decimal rvUField;

        /// <remarks/>
        public decimal RvA
        {
            get
            {
                return this.rvAField;
            }
            set
            {
                this.rvAField = value;
            }
        }

        /// <remarks/>
        public decimal RvU
        {
            get
            {
                return this.rvUField;
            }
            set
            {
                this.rvUField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.energiatodistusrekisteri.fi/ws/energiatodistustypes")]
    public partial class EnergiatodistusIlmoitusEnergiatodistusLahtotiedotLahtotiedotRakennusvaippaRvUlkoovet
    {

        private decimal rvAField;

        private decimal rvUField;

        /// <remarks/>
        public decimal RvA
        {
            get
            {
                return this.rvAField;
            }
            set
            {
                this.rvAField = value;
            }
        }

        /// <remarks/>
        public decimal RvU
        {
            get
            {
                return this.rvUField;
            }
            set
            {
                this.rvUField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.energiatodistusrekisteri.fi/ws/energiatodistustypes")]
    public partial class EnergiatodistusIlmoitusEnergiatodistusLahtotiedotLahtotiedotIkkunat
    {

        private EnergiatodistusIlmoitusEnergiatodistusLahtotiedotLahtotiedotIkkunatPohjoinen pohjoinenField;

        private EnergiatodistusIlmoitusEnergiatodistusLahtotiedotLahtotiedotIkkunatKoillinen koillinenField;

        private EnergiatodistusIlmoitusEnergiatodistusLahtotiedotLahtotiedotIkkunatIta itaField;

        private EnergiatodistusIlmoitusEnergiatodistusLahtotiedotLahtotiedotIkkunatKaakko kaakkoField;

        private EnergiatodistusIlmoitusEnergiatodistusLahtotiedotLahtotiedotIkkunatEtela etelaField;

        private EnergiatodistusIlmoitusEnergiatodistusLahtotiedotLahtotiedotIkkunatLounas lounasField;

        private EnergiatodistusIlmoitusEnergiatodistusLahtotiedotLahtotiedotIkkunatLansi lansiField;

        private EnergiatodistusIlmoitusEnergiatodistusLahtotiedotLahtotiedotIkkunatLuode luodeField;

        /// <remarks/>
        public EnergiatodistusIlmoitusEnergiatodistusLahtotiedotLahtotiedotIkkunatPohjoinen Pohjoinen
        {
            get
            {
                return this.pohjoinenField;
            }
            set
            {
                this.pohjoinenField = value;
            }
        }

        /// <remarks/>
        public EnergiatodistusIlmoitusEnergiatodistusLahtotiedotLahtotiedotIkkunatKoillinen Koillinen
        {
            get
            {
                return this.koillinenField;
            }
            set
            {
                this.koillinenField = value;
            }
        }

        /// <remarks/>
        public EnergiatodistusIlmoitusEnergiatodistusLahtotiedotLahtotiedotIkkunatIta Ita
        {
            get
            {
                return this.itaField;
            }
            set
            {
                this.itaField = value;
            }
        }

        /// <remarks/>
        public EnergiatodistusIlmoitusEnergiatodistusLahtotiedotLahtotiedotIkkunatKaakko Kaakko
        {
            get
            {
                return this.kaakkoField;
            }
            set
            {
                this.kaakkoField = value;
            }
        }

        /// <remarks/>
        public EnergiatodistusIlmoitusEnergiatodistusLahtotiedotLahtotiedotIkkunatEtela Etela
        {
            get
            {
                return this.etelaField;
            }
            set
            {
                this.etelaField = value;
            }
        }

        /// <remarks/>
        public EnergiatodistusIlmoitusEnergiatodistusLahtotiedotLahtotiedotIkkunatLounas Lounas
        {
            get
            {
                return this.lounasField;
            }
            set
            {
                this.lounasField = value;
            }
        }

        /// <remarks/>
        public EnergiatodistusIlmoitusEnergiatodistusLahtotiedotLahtotiedotIkkunatLansi Lansi
        {
            get
            {
                return this.lansiField;
            }
            set
            {
                this.lansiField = value;
            }
        }

        /// <remarks/>
        public EnergiatodistusIlmoitusEnergiatodistusLahtotiedotLahtotiedotIkkunatLuode Luode
        {
            get
            {
                return this.luodeField;
            }
            set
            {
                this.luodeField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.energiatodistusrekisteri.fi/ws/energiatodistustypes")]
    public partial class EnergiatodistusIlmoitusEnergiatodistusLahtotiedotLahtotiedotIkkunatPohjoinen
    {

        private decimal ikkAField;

        private decimal ikkUField;

        private decimal ikkGField;

        /// <remarks/>
        public decimal IkkA
        {
            get
            {
                return this.ikkAField;
            }
            set
            {
                this.ikkAField = value;
            }
        }

        /// <remarks/>
        public decimal IkkU
        {
            get
            {
                return this.ikkUField;
            }
            set
            {
                this.ikkUField = value;
            }
        }

        /// <remarks/>
        public decimal IkkG
        {
            get
            {
                return this.ikkGField;
            }
            set
            {
                this.ikkGField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.energiatodistusrekisteri.fi/ws/energiatodistustypes")]
    public partial class EnergiatodistusIlmoitusEnergiatodistusLahtotiedotLahtotiedotIkkunatKoillinen
    {

        private decimal ikkAField;

        private decimal ikkUField;

        private decimal ikkGField;

        /// <remarks/>
        public decimal IkkA
        {
            get
            {
                return this.ikkAField;
            }
            set
            {
                this.ikkAField = value;
            }
        }

        /// <remarks/>
        public decimal IkkU
        {
            get
            {
                return this.ikkUField;
            }
            set
            {
                this.ikkUField = value;
            }
        }

        /// <remarks/>
        public decimal IkkG
        {
            get
            {
                return this.ikkGField;
            }
            set
            {
                this.ikkGField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.energiatodistusrekisteri.fi/ws/energiatodistustypes")]
    public partial class EnergiatodistusIlmoitusEnergiatodistusLahtotiedotLahtotiedotIkkunatIta
    {

        private decimal ikkAField;

        private decimal ikkUField;

        private decimal ikkGField;

        /// <remarks/>
        public decimal IkkA
        {
            get
            {
                return this.ikkAField;
            }
            set
            {
                this.ikkAField = value;
            }
        }

        /// <remarks/>
        public decimal IkkU
        {
            get
            {
                return this.ikkUField;
            }
            set
            {
                this.ikkUField = value;
            }
        }

        /// <remarks/>
        public decimal IkkG
        {
            get
            {
                return this.ikkGField;
            }
            set
            {
                this.ikkGField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.energiatodistusrekisteri.fi/ws/energiatodistustypes")]
    public partial class EnergiatodistusIlmoitusEnergiatodistusLahtotiedotLahtotiedotIkkunatKaakko
    {

        private decimal ikkAField;

        private decimal ikkUField;

        private decimal ikkGField;

        /// <remarks/>
        public decimal IkkA
        {
            get
            {
                return this.ikkAField;
            }
            set
            {
                this.ikkAField = value;
            }
        }

        /// <remarks/>
        public decimal IkkU
        {
            get
            {
                return this.ikkUField;
            }
            set
            {
                this.ikkUField = value;
            }
        }

        /// <remarks/>
        public decimal IkkG
        {
            get
            {
                return this.ikkGField;
            }
            set
            {
                this.ikkGField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.energiatodistusrekisteri.fi/ws/energiatodistustypes")]
    public partial class EnergiatodistusIlmoitusEnergiatodistusLahtotiedotLahtotiedotIkkunatEtela
    {

        private decimal ikkAField;

        private decimal ikkUField;

        private decimal ikkGField;

        /// <remarks/>
        public decimal IkkA
        {
            get
            {
                return this.ikkAField;
            }
            set
            {
                this.ikkAField = value;
            }
        }

        /// <remarks/>
        public decimal IkkU
        {
            get
            {
                return this.ikkUField;
            }
            set
            {
                this.ikkUField = value;
            }
        }

        /// <remarks/>
        public decimal IkkG
        {
            get
            {
                return this.ikkGField;
            }
            set
            {
                this.ikkGField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.energiatodistusrekisteri.fi/ws/energiatodistustypes")]
    public partial class EnergiatodistusIlmoitusEnergiatodistusLahtotiedotLahtotiedotIkkunatLounas
    {

        private decimal ikkAField;

        private decimal ikkUField;

        private decimal ikkGField;

        /// <remarks/>
        public decimal IkkA
        {
            get
            {
                return this.ikkAField;
            }
            set
            {
                this.ikkAField = value;
            }
        }

        /// <remarks/>
        public decimal IkkU
        {
            get
            {
                return this.ikkUField;
            }
            set
            {
                this.ikkUField = value;
            }
        }

        /// <remarks/>
        public decimal IkkG
        {
            get
            {
                return this.ikkGField;
            }
            set
            {
                this.ikkGField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.energiatodistusrekisteri.fi/ws/energiatodistustypes")]
    public partial class EnergiatodistusIlmoitusEnergiatodistusLahtotiedotLahtotiedotIkkunatLansi
    {

        private decimal ikkAField;

        private decimal ikkUField;

        private decimal ikkGField;

        /// <remarks/>
        public decimal IkkA
        {
            get
            {
                return this.ikkAField;
            }
            set
            {
                this.ikkAField = value;
            }
        }

        /// <remarks/>
        public decimal IkkU
        {
            get
            {
                return this.ikkUField;
            }
            set
            {
                this.ikkUField = value;
            }
        }

        /// <remarks/>
        public decimal IkkG
        {
            get
            {
                return this.ikkGField;
            }
            set
            {
                this.ikkGField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.energiatodistusrekisteri.fi/ws/energiatodistustypes")]
    public partial class EnergiatodistusIlmoitusEnergiatodistusLahtotiedotLahtotiedotIkkunatLuode
    {

        private decimal ikkAField;

        private decimal ikkUField;

        private decimal ikkGField;

        /// <remarks/>
        public decimal IkkA
        {
            get
            {
                return this.ikkAField;
            }
            set
            {
                this.ikkAField = value;
            }
        }

        /// <remarks/>
        public decimal IkkU
        {
            get
            {
                return this.ikkUField;
            }
            set
            {
                this.ikkUField = value;
            }
        }

        /// <remarks/>
        public decimal IkkG
        {
            get
            {
                return this.ikkGField;
            }
            set
            {
                this.ikkGField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.energiatodistusrekisteri.fi/ws/energiatodistustypes")]
    public partial class EnergiatodistusIlmoitusEnergiatodistusLahtotiedotLahtotiedotIlmanvaihto
    {

        private string ivKuvaus_FiField;

        private string ivKuvaus_SvField;

        private decimal ivPaaivTuloField;

        private decimal ivPaaivPoistoField;

        private decimal ivPaaivSfpField;

        private decimal ivPaaivLampotilasuhdeField;

        private decimal ivPaaivJaatymisenestoField;

        private decimal ivErillispoistotTuloField;

        private decimal ivErillispoistotPoistoField;

        private decimal ivErillispoistotSfpField;

        private decimal ivIvjarjestelmaTuloField;

        private decimal ivIvjarjestelmaPoistoField;

        private decimal ivIvjarjestelmaSfpField;

        private decimal ivLtoVuosihyotysuhdeField;

        /// <remarks/>
        public string IvKuvaus_Fi
        {
            get
            {
                return this.ivKuvaus_FiField;
            }
            set
            {
                this.ivKuvaus_FiField = value;
            }
        }

        /// <remarks/>
        public string IvKuvaus_Sv
        {
            get
            {
                return this.ivKuvaus_SvField;
            }
            set
            {
                this.ivKuvaus_SvField = value;
            }
        }

        /// <remarks/>
        public decimal IvPaaivTulo
        {
            get
            {
                return this.ivPaaivTuloField;
            }
            set
            {
                this.ivPaaivTuloField = value;
            }
        }

        /// <remarks/>
        public decimal IvPaaivPoisto
        {
            get
            {
                return this.ivPaaivPoistoField;
            }
            set
            {
                this.ivPaaivPoistoField = value;
            }
        }

        /// <remarks/>
        public decimal IvPaaivSfp
        {
            get
            {
                return this.ivPaaivSfpField;
            }
            set
            {
                this.ivPaaivSfpField = value;
            }
        }

        /// <remarks/>
        public decimal IvPaaivLampotilasuhde
        {
            get
            {
                return this.ivPaaivLampotilasuhdeField;
            }
            set
            {
                this.ivPaaivLampotilasuhdeField = value;
            }
        }

        /// <remarks/>
        public decimal IvPaaivJaatymisenesto
        {
            get
            {
                return this.ivPaaivJaatymisenestoField;
            }
            set
            {
                this.ivPaaivJaatymisenestoField = value;
            }
        }

        /// <remarks/>
        public decimal IvErillispoistotTulo
        {
            get
            {
                return this.ivErillispoistotTuloField;
            }
            set
            {
                this.ivErillispoistotTuloField = value;
            }
        }

        /// <remarks/>
        public decimal IvErillispoistotPoisto
        {
            get
            {
                return this.ivErillispoistotPoistoField;
            }
            set
            {
                this.ivErillispoistotPoistoField = value;
            }
        }

        /// <remarks/>
        public decimal IvErillispoistotSfp
        {
            get
            {
                return this.ivErillispoistotSfpField;
            }
            set
            {
                this.ivErillispoistotSfpField = value;
            }
        }

        /// <remarks/>
        public decimal IvIvjarjestelmaTulo
        {
            get
            {
                return this.ivIvjarjestelmaTuloField;
            }
            set
            {
                this.ivIvjarjestelmaTuloField = value;
            }
        }

        /// <remarks/>
        public decimal IvIvjarjestelmaPoisto
        {
            get
            {
                return this.ivIvjarjestelmaPoistoField;
            }
            set
            {
                this.ivIvjarjestelmaPoistoField = value;
            }
        }

        /// <remarks/>
        public decimal IvIvjarjestelmaSfp
        {
            get
            {
                return this.ivIvjarjestelmaSfpField;
            }
            set
            {
                this.ivIvjarjestelmaSfpField = value;
            }
        }

        /// <remarks/>
        public decimal IvLtoVuosihyotysuhde
        {
            get
            {
                return this.ivLtoVuosihyotysuhdeField;
            }
            set
            {
                this.ivLtoVuosihyotysuhdeField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.energiatodistusrekisteri.fi/ws/energiatodistustypes")]
    public partial class EnergiatodistusIlmoitusEnergiatodistusLahtotiedotLahtotiedotLammitys
    {

        private string lammitysKuvaus_FiField;

        private string lammitysKuvaus_SvField;

        private EnergiatodistusIlmoitusEnergiatodistusLahtotiedotLahtotiedotLammitysLammitysTilatJaIv lammitysTilatJaIvField;

        private EnergiatodistusIlmoitusEnergiatodistusLahtotiedotLahtotiedotLammitysLammitysLamminKayttovesi lammitysLamminKayttovesiField;

        private EnergiatodistusIlmoitusEnergiatodistusLahtotiedotLahtotiedotLammitysLammitysTakka lammitysTakkaField;

        private EnergiatodistusIlmoitusEnergiatodistusLahtotiedotLahtotiedotLammitysLammitysIlmanlampopumppu lammitysIlmanlampopumppuField;

        /// <remarks/>
        public string LammitysKuvaus_Fi
        {
            get
            {
                return this.lammitysKuvaus_FiField;
            }
            set
            {
                this.lammitysKuvaus_FiField = value;
            }
        }

        /// <remarks/>
        public string LammitysKuvaus_Sv
        {
            get
            {
                return this.lammitysKuvaus_SvField;
            }
            set
            {
                this.lammitysKuvaus_SvField = value;
            }
        }

        /// <remarks/>
        public EnergiatodistusIlmoitusEnergiatodistusLahtotiedotLahtotiedotLammitysLammitysTilatJaIv LammitysTilatJaIv
        {
            get
            {
                return this.lammitysTilatJaIvField;
            }
            set
            {
                this.lammitysTilatJaIvField = value;
            }
        }

        /// <remarks/>
        public EnergiatodistusIlmoitusEnergiatodistusLahtotiedotLahtotiedotLammitysLammitysLamminKayttovesi LammitysLamminKayttovesi
        {
            get
            {
                return this.lammitysLamminKayttovesiField;
            }
            set
            {
                this.lammitysLamminKayttovesiField = value;
            }
        }

        /// <remarks/>
        public EnergiatodistusIlmoitusEnergiatodistusLahtotiedotLahtotiedotLammitysLammitysTakka LammitysTakka
        {
            get
            {
                return this.lammitysTakkaField;
            }
            set
            {
                this.lammitysTakkaField = value;
            }
        }

        /// <remarks/>
        public EnergiatodistusIlmoitusEnergiatodistusLahtotiedotLahtotiedotLammitysLammitysIlmanlampopumppu LammitysIlmanlampopumppu
        {
            get
            {
                return this.lammitysIlmanlampopumppuField;
            }
            set
            {
                this.lammitysIlmanlampopumppuField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.energiatodistusrekisteri.fi/ws/energiatodistustypes")]
    public partial class EnergiatodistusIlmoitusEnergiatodistusLahtotiedotLahtotiedotLammitysLammitysTilatJaIv
    {

        private decimal tuotonHyotysuhdeField;

        private decimal jaonHyotysuhdeField;

        private decimal lampokerroinField;

        private decimal apulaitteetField;

        /// <remarks/>
        public decimal TuotonHyotysuhde
        {
            get
            {
                return this.tuotonHyotysuhdeField;
            }
            set
            {
                this.tuotonHyotysuhdeField = value;
            }
        }

        /// <remarks/>
        public decimal JaonHyotysuhde
        {
            get
            {
                return this.jaonHyotysuhdeField;
            }
            set
            {
                this.jaonHyotysuhdeField = value;
            }
        }

        /// <remarks/>
        public decimal Lampokerroin
        {
            get
            {
                return this.lampokerroinField;
            }
            set
            {
                this.lampokerroinField = value;
            }
        }

        /// <remarks/>
        public decimal Apulaitteet
        {
            get
            {
                return this.apulaitteetField;
            }
            set
            {
                this.apulaitteetField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.energiatodistusrekisteri.fi/ws/energiatodistustypes")]
    public partial class EnergiatodistusIlmoitusEnergiatodistusLahtotiedotLahtotiedotLammitysLammitysLamminKayttovesi
    {

        private decimal tuotonHyotysuhdeField;

        private decimal jaonHyotysuhdeField;

        private decimal lampokerroinField;

        private decimal apulaitteetField;

        /// <remarks/>
        public decimal TuotonHyotysuhde
        {
            get
            {
                return this.tuotonHyotysuhdeField;
            }
            set
            {
                this.tuotonHyotysuhdeField = value;
            }
        }

        /// <remarks/>
        public decimal JaonHyotysuhde
        {
            get
            {
                return this.jaonHyotysuhdeField;
            }
            set
            {
                this.jaonHyotysuhdeField = value;
            }
        }

        /// <remarks/>
        public decimal Lampokerroin
        {
            get
            {
                return this.lampokerroinField;
            }
            set
            {
                this.lampokerroinField = value;
            }
        }

        /// <remarks/>
        public decimal Apulaitteet
        {
            get
            {
                return this.apulaitteetField;
            }
            set
            {
                this.apulaitteetField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.energiatodistusrekisteri.fi/ws/energiatodistustypes")]
    public partial class EnergiatodistusIlmoitusEnergiatodistusLahtotiedotLahtotiedotLammitysLammitysTakka
    {

        private byte maaraField;

        private decimal tuottoField;

        /// <remarks/>
        public byte Maara
        {
            get
            {
                return this.maaraField;
            }
            set
            {
                this.maaraField = value;
            }
        }

        /// <remarks/>
        public decimal Tuotto
        {
            get
            {
                return this.tuottoField;
            }
            set
            {
                this.tuottoField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.energiatodistusrekisteri.fi/ws/energiatodistustypes")]
    public partial class EnergiatodistusIlmoitusEnergiatodistusLahtotiedotLahtotiedotLammitysLammitysIlmanlampopumppu
    {

        private byte maaraField;

        private decimal tuottoField;

        /// <remarks/>
        public byte Maara
        {
            get
            {
                return this.maaraField;
            }
            set
            {
                this.maaraField = value;
            }
        }

        /// <remarks/>
        public decimal Tuotto
        {
            get
            {
                return this.tuottoField;
            }
            set
            {
                this.tuottoField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.energiatodistusrekisteri.fi/ws/energiatodistustypes")]
    public partial class EnergiatodistusIlmoitusEnergiatodistusLahtotiedotLahtotiedotJaahdytysjarjestelma
    {

        private decimal jaahdytysjarjestelmaJaahdytyskaudenPainotettuKylmakerroinField;

        /// <remarks/>
        public decimal JaahdytysjarjestelmaJaahdytyskaudenPainotettuKylmakerroin
        {
            get
            {
                return this.jaahdytysjarjestelmaJaahdytyskaudenPainotettuKylmakerroinField;
            }
            set
            {
                this.jaahdytysjarjestelmaJaahdytyskaudenPainotettuKylmakerroinField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.energiatodistusrekisteri.fi/ws/energiatodistustypes")]
    public partial class EnergiatodistusIlmoitusEnergiatodistusLahtotiedotLahtotiedotLkvnKaytto
    {

        private decimal lkvnKayttoKulutusPerNelioField;

        private decimal lkvnKayttoVuosikulutusField;

        /// <remarks/>
        public decimal LkvnKayttoKulutusPerNelio
        {
            get
            {
                return this.lkvnKayttoKulutusPerNelioField;
            }
            set
            {
                this.lkvnKayttoKulutusPerNelioField = value;
            }
        }

        /// <remarks/>
        public decimal LkvnKayttoVuosikulutus
        {
            get
            {
                return this.lkvnKayttoVuosikulutusField;
            }
            set
            {
                this.lkvnKayttoVuosikulutusField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.energiatodistusrekisteri.fi/ws/energiatodistustypes")]
    public partial class EnergiatodistusIlmoitusEnergiatodistusLahtotiedotSisKuorma
    {

        private string selite_FiField;

        private string selite_SvField;

        private decimal kayttoasteField;

        private decimal valaistusField;

        private bool valaistusFieldSpecified;

        private decimal henkilotField;

        private bool henkilotFieldSpecified;

        private decimal kuluttajalaitteetField;

        private bool kuluttajalaitteetFieldSpecified;

        /// <remarks/>
        public string Selite_Fi
        {
            get
            {
                return this.selite_FiField;
            }
            set
            {
                this.selite_FiField = value;
            }
        }

        /// <remarks/>
        public string Selite_Sv
        {
            get
            {
                return this.selite_SvField;
            }
            set
            {
                this.selite_SvField = value;
            }
        }

        /// <remarks/>
        public decimal Kayttoaste
        {
            get
            {
                return this.kayttoasteField;
            }
            set
            {
                this.kayttoasteField = value;
            }
        }

        /// <remarks/>
        public decimal Valaistus
        {
            get
            {
                return this.valaistusField;
            }
            set
            {
                this.valaistusField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ValaistusSpecified
        {
            get
            {
                return this.valaistusFieldSpecified;
            }
            set
            {
                this.valaistusFieldSpecified = value;
            }
        }

        /// <remarks/>
        public decimal Henkilot
        {
            get
            {
                return this.henkilotField;
            }
            set
            {
                this.henkilotField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool HenkilotSpecified
        {
            get
            {
                return this.henkilotFieldSpecified;
            }
            set
            {
                this.henkilotFieldSpecified = value;
            }
        }

        /// <remarks/>
        public decimal Kuluttajalaitteet
        {
            get
            {
                return this.kuluttajalaitteetField;
            }
            set
            {
                this.kuluttajalaitteetField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool KuluttajalaitteetSpecified
        {
            get
            {
                return this.kuluttajalaitteetFieldSpecified;
            }
            set
            {
                this.kuluttajalaitteetFieldSpecified = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.energiatodistusrekisteri.fi/ws/energiatodistustypes")]
    public partial class EnergiatodistusIlmoitusEnergiatodistusTulokset
    {

        private EnergiatodistusIlmoitusEnergiatodistusTuloksetKaytettavaEnergiamuoto[] tuloksetKaytettavatEnergiamuodotField;

        private EnergiatodistusIlmoitusEnergiatodistusTuloksetUusiutuvaOmavaraisenergia[] tuloksetUusiutuvatOmavaraisenergiatField;

        private EnergiatodistusIlmoitusEnergiatodistusTuloksetTuloksetTeknisetJarjestelmat tuloksetTeknisetJarjestelmatField;

        private EnergiatodistusIlmoitusEnergiatodistusTuloksetTuloksetNettotarve tuloksetNettotarveField;

        private EnergiatodistusIlmoitusEnergiatodistusTuloksetTuloksetLampokuormat tuloksetLampokuormatField;

        private string tuloksetLaskentatyokaluField;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("KaytettavaEnergiamuoto", IsNullable = false)]
        public EnergiatodistusIlmoitusEnergiatodistusTuloksetKaytettavaEnergiamuoto[] TuloksetKaytettavatEnergiamuodot
        {
            get
            {
                return this.tuloksetKaytettavatEnergiamuodotField;
            }
            set
            {
                this.tuloksetKaytettavatEnergiamuodotField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("UusiutuvaOmavaraisenergia", IsNullable = false)]
        public EnergiatodistusIlmoitusEnergiatodistusTuloksetUusiutuvaOmavaraisenergia[] TuloksetUusiutuvatOmavaraisenergiat
        {
            get
            {
                return this.tuloksetUusiutuvatOmavaraisenergiatField;
            }
            set
            {
                this.tuloksetUusiutuvatOmavaraisenergiatField = value;
            }
        }

        /// <remarks/>
        public EnergiatodistusIlmoitusEnergiatodistusTuloksetTuloksetTeknisetJarjestelmat TuloksetTeknisetJarjestelmat
        {
            get
            {
                return this.tuloksetTeknisetJarjestelmatField;
            }
            set
            {
                this.tuloksetTeknisetJarjestelmatField = value;
            }
        }

        /// <remarks/>
        public EnergiatodistusIlmoitusEnergiatodistusTuloksetTuloksetNettotarve TuloksetNettotarve
        {
            get
            {
                return this.tuloksetNettotarveField;
            }
            set
            {
                this.tuloksetNettotarveField = value;
            }
        }

        /// <remarks/>
        public EnergiatodistusIlmoitusEnergiatodistusTuloksetTuloksetLampokuormat TuloksetLampokuormat
        {
            get
            {
                return this.tuloksetLampokuormatField;
            }
            set
            {
                this.tuloksetLampokuormatField = value;
            }
        }

        /// <remarks/>
        public string TuloksetLaskentatyokalu
        {
            get
            {
                return this.tuloksetLaskentatyokaluField;
            }
            set
            {
                this.tuloksetLaskentatyokaluField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.energiatodistusrekisteri.fi/ws/energiatodistustypes")]
    public partial class EnergiatodistusIlmoitusEnergiatodistusTuloksetKaytettavaEnergiamuoto
    {

        private string energiamuotoVapaaField;

        private decimal energiamuodonKerroinField;

        private bool energiamuodonKerroinFieldSpecified;

        private string energiamuotoVakioField;

        private decimal laskettuOstoenergiaField;

        /// <remarks/>
        public string EnergiamuotoVapaa
        {
            get
            {
                return this.energiamuotoVapaaField;
            }
            set
            {
                this.energiamuotoVapaaField = value;
            }
        }

        /// <remarks/>
        public decimal EnergiamuodonKerroin
        {
            get
            {
                return this.energiamuodonKerroinField;
            }
            set
            {
                this.energiamuodonKerroinField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool EnergiamuodonKerroinSpecified
        {
            get
            {
                return this.energiamuodonKerroinFieldSpecified;
            }
            set
            {
                this.energiamuodonKerroinFieldSpecified = value;
            }
        }

        /// <remarks/>
        public string EnergiamuotoVakio
        {
            get
            {
                return this.energiamuotoVakioField;
            }
            set
            {
                this.energiamuotoVakioField = value;
            }
        }

        /// <remarks/>
        public decimal LaskettuOstoenergia
        {
            get
            {
                return this.laskettuOstoenergiaField;
            }
            set
            {
                this.laskettuOstoenergiaField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.energiatodistusrekisteri.fi/ws/energiatodistustypes")]
    public partial class EnergiatodistusIlmoitusEnergiatodistusTuloksetUusiutuvaOmavaraisenergia
    {

        private string nimiField;

        private decimal vuosikulutusField;

        /// <remarks/>
        public string Nimi
        {
            get
            {
                return this.nimiField;
            }
            set
            {
                this.nimiField = value;
            }
        }

        /// <remarks/>
        public decimal Vuosikulutus
        {
            get
            {
                return this.vuosikulutusField;
            }
            set
            {
                this.vuosikulutusField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.energiatodistusrekisteri.fi/ws/energiatodistustypes")]
    public partial class EnergiatodistusIlmoitusEnergiatodistusTuloksetTuloksetTeknisetJarjestelmat
    {

        private EnergiatodistusIlmoitusEnergiatodistusTuloksetTuloksetTeknisetJarjestelmatTjTilojenLammitys tjTilojenLammitysField;

        private EnergiatodistusIlmoitusEnergiatodistusTuloksetTuloksetTeknisetJarjestelmatTjTuloilmanLammitys tjTuloilmanLammitysField;

        private EnergiatodistusIlmoitusEnergiatodistusTuloksetTuloksetTeknisetJarjestelmatTjKayttovedenValmistus tjKayttovedenValmistusField;

        private decimal tjIvSahkoField;

        private EnergiatodistusIlmoitusEnergiatodistusTuloksetTuloksetTeknisetJarjestelmatTjJaahdytys tjJaahdytysField;

        private decimal tjKuluttajalaitteetJaValaistusSahkoField;

        /// <remarks/>
        public EnergiatodistusIlmoitusEnergiatodistusTuloksetTuloksetTeknisetJarjestelmatTjTilojenLammitys TjTilojenLammitys
        {
            get
            {
                return this.tjTilojenLammitysField;
            }
            set
            {
                this.tjTilojenLammitysField = value;
            }
        }

        /// <remarks/>
        public EnergiatodistusIlmoitusEnergiatodistusTuloksetTuloksetTeknisetJarjestelmatTjTuloilmanLammitys TjTuloilmanLammitys
        {
            get
            {
                return this.tjTuloilmanLammitysField;
            }
            set
            {
                this.tjTuloilmanLammitysField = value;
            }
        }

        /// <remarks/>
        public EnergiatodistusIlmoitusEnergiatodistusTuloksetTuloksetTeknisetJarjestelmatTjKayttovedenValmistus TjKayttovedenValmistus
        {
            get
            {
                return this.tjKayttovedenValmistusField;
            }
            set
            {
                this.tjKayttovedenValmistusField = value;
            }
        }

        /// <remarks/>
        public decimal TjIvSahko
        {
            get
            {
                return this.tjIvSahkoField;
            }
            set
            {
                this.tjIvSahkoField = value;
            }
        }

        /// <remarks/>
        public EnergiatodistusIlmoitusEnergiatodistusTuloksetTuloksetTeknisetJarjestelmatTjJaahdytys TjJaahdytys
        {
            get
            {
                return this.tjJaahdytysField;
            }
            set
            {
                this.tjJaahdytysField = value;
            }
        }

        /// <remarks/>
        public decimal TjKuluttajalaitteetJaValaistusSahko
        {
            get
            {
                return this.tjKuluttajalaitteetJaValaistusSahkoField;
            }
            set
            {
                this.tjKuluttajalaitteetJaValaistusSahkoField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.energiatodistusrekisteri.fi/ws/energiatodistustypes")]
    public partial class EnergiatodistusIlmoitusEnergiatodistusTuloksetTuloksetTeknisetJarjestelmatTjTilojenLammitys
    {

        private decimal sahkoField;

        private decimal lampoField;

        /// <remarks/>
        public decimal Sahko
        {
            get
            {
                return this.sahkoField;
            }
            set
            {
                this.sahkoField = value;
            }
        }

        /// <remarks/>
        public decimal Lampo
        {
            get
            {
                return this.lampoField;
            }
            set
            {
                this.lampoField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.energiatodistusrekisteri.fi/ws/energiatodistustypes")]
    public partial class EnergiatodistusIlmoitusEnergiatodistusTuloksetTuloksetTeknisetJarjestelmatTjTuloilmanLammitys
    {

        private decimal sahkoField;

        private decimal lampoField;

        /// <remarks/>
        public decimal Sahko
        {
            get
            {
                return this.sahkoField;
            }
            set
            {
                this.sahkoField = value;
            }
        }

        /// <remarks/>
        public decimal Lampo
        {
            get
            {
                return this.lampoField;
            }
            set
            {
                this.lampoField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.energiatodistusrekisteri.fi/ws/energiatodistustypes")]
    public partial class EnergiatodistusIlmoitusEnergiatodistusTuloksetTuloksetTeknisetJarjestelmatTjKayttovedenValmistus
    {

        private decimal sahkoField;

        private decimal lampoField;

        /// <remarks/>
        public decimal Sahko
        {
            get
            {
                return this.sahkoField;
            }
            set
            {
                this.sahkoField = value;
            }
        }

        /// <remarks/>
        public decimal Lampo
        {
            get
            {
                return this.lampoField;
            }
            set
            {
                this.lampoField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.energiatodistusrekisteri.fi/ws/energiatodistustypes")]
    public partial class EnergiatodistusIlmoitusEnergiatodistusTuloksetTuloksetTeknisetJarjestelmatTjJaahdytys
    {

        private decimal sahkoField;

        private decimal lampoField;

        private decimal kaukojaahdytysField;

        /// <remarks/>
        public decimal Sahko
        {
            get
            {
                return this.sahkoField;
            }
            set
            {
                this.sahkoField = value;
            }
        }

        /// <remarks/>
        public decimal Lampo
        {
            get
            {
                return this.lampoField;
            }
            set
            {
                this.lampoField = value;
            }
        }

        /// <remarks/>
        public decimal Kaukojaahdytys
        {
            get
            {
                return this.kaukojaahdytysField;
            }
            set
            {
                this.kaukojaahdytysField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.energiatodistusrekisteri.fi/ws/energiatodistustypes")]
    public partial class EnergiatodistusIlmoitusEnergiatodistusTuloksetTuloksetNettotarve
    {

        private decimal ntTilojenLammitysVuosikulutusField;

        private decimal ntIlmanvaihdonLammitysVuosikulutusField;

        private decimal ntKayttovedenValmistusVuosikulutusField;

        private decimal ntJaahdytysVuosikulutusField;

        /// <remarks/>
        public decimal NtTilojenLammitysVuosikulutus
        {
            get
            {
                return this.ntTilojenLammitysVuosikulutusField;
            }
            set
            {
                this.ntTilojenLammitysVuosikulutusField = value;
            }
        }

        /// <remarks/>
        public decimal NtIlmanvaihdonLammitysVuosikulutus
        {
            get
            {
                return this.ntIlmanvaihdonLammitysVuosikulutusField;
            }
            set
            {
                this.ntIlmanvaihdonLammitysVuosikulutusField = value;
            }
        }

        /// <remarks/>
        public decimal NtKayttovedenValmistusVuosikulutus
        {
            get
            {
                return this.ntKayttovedenValmistusVuosikulutusField;
            }
            set
            {
                this.ntKayttovedenValmistusVuosikulutusField = value;
            }
        }

        /// <remarks/>
        public decimal NtJaahdytysVuosikulutus
        {
            get
            {
                return this.ntJaahdytysVuosikulutusField;
            }
            set
            {
                this.ntJaahdytysVuosikulutusField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.energiatodistusrekisteri.fi/ws/energiatodistustypes")]
    public partial class EnergiatodistusIlmoitusEnergiatodistusTuloksetTuloksetLampokuormat
    {

        private decimal lkAurinkoField;

        private decimal lkIhmisetField;

        private decimal lkKuluttajalaitteetField;

        private decimal lkValaistusField;

        private decimal lkKvesiField;

        /// <remarks/>
        public decimal LkAurinko
        {
            get
            {
                return this.lkAurinkoField;
            }
            set
            {
                this.lkAurinkoField = value;
            }
        }

        /// <remarks/>
        public decimal LkIhmiset
        {
            get
            {
                return this.lkIhmisetField;
            }
            set
            {
                this.lkIhmisetField = value;
            }
        }

        /// <remarks/>
        public decimal LkKuluttajalaitteet
        {
            get
            {
                return this.lkKuluttajalaitteetField;
            }
            set
            {
                this.lkKuluttajalaitteetField = value;
            }
        }

        /// <remarks/>
        public decimal LkValaistus
        {
            get
            {
                return this.lkValaistusField;
            }
            set
            {
                this.lkValaistusField = value;
            }
        }

        /// <remarks/>
        public decimal LkKvesi
        {
            get
            {
                return this.lkKvesiField;
            }
            set
            {
                this.lkKvesiField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.energiatodistusrekisteri.fi/ws/energiatodistustypes")]
    public partial class EnergiatodistusIlmoitusEnergiatodistusToteutunutOstoenergiankulutus
    {

        private EnergiatodistusIlmoitusEnergiatodistusToteutunutOstoenergiankulutusOstettuEnergia ostettuEnergiaField;

        private EnergiatodistusIlmoitusEnergiatodistusToteutunutOstoenergiankulutusOpVapaa[] ostetutPolttoaineetField;

        private decimal toSahkoVuosikulutusYhteensaField;

        private decimal toKaukolampoVuosikulutusYhteensaField;

        private decimal toPolttoaineetVuosikulutusYhteensaField;

        private decimal toKaukojaahdytysVuosikulutusYhteensaField;

        /// <remarks/>
        public EnergiatodistusIlmoitusEnergiatodistusToteutunutOstoenergiankulutusOstettuEnergia OstettuEnergia
        {
            get
            {
                return this.ostettuEnergiaField;
            }
            set
            {
                this.ostettuEnergiaField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("OpVapaa", IsNullable = false)]
        public EnergiatodistusIlmoitusEnergiatodistusToteutunutOstoenergiankulutusOpVapaa[] OstetutPolttoaineet
        {
            get
            {
                return this.ostetutPolttoaineetField;
            }
            set
            {
                this.ostetutPolttoaineetField = value;
            }
        }

        /// <remarks/>
        public decimal ToSahkoVuosikulutusYhteensa
        {
            get
            {
                return this.toSahkoVuosikulutusYhteensaField;
            }
            set
            {
                this.toSahkoVuosikulutusYhteensaField = value;
            }
        }

        /// <remarks/>
        public decimal ToKaukolampoVuosikulutusYhteensa
        {
            get
            {
                return this.toKaukolampoVuosikulutusYhteensaField;
            }
            set
            {
                this.toKaukolampoVuosikulutusYhteensaField = value;
            }
        }

        /// <remarks/>
        public decimal ToPolttoaineetVuosikulutusYhteensa
        {
            get
            {
                return this.toPolttoaineetVuosikulutusYhteensaField;
            }
            set
            {
                this.toPolttoaineetVuosikulutusYhteensaField = value;
            }
        }

        /// <remarks/>
        public decimal ToKaukojaahdytysVuosikulutusYhteensa
        {
            get
            {
                return this.toKaukojaahdytysVuosikulutusYhteensaField;
            }
            set
            {
                this.toKaukojaahdytysVuosikulutusYhteensaField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.energiatodistusrekisteri.fi/ws/energiatodistustypes")]
    public partial class EnergiatodistusIlmoitusEnergiatodistusToteutunutOstoenergiankulutusOstettuEnergia
    {

        private decimal toKaukolampoVuosikulutusField;

        private decimal toKokonaissahkoVuosikulutusField;

        private decimal toKiinteistosahkoVuosikulutusField;

        private decimal toKayttajasahkoVuosikulutusField;

        private decimal toKaukojaahdytysVuosikulutusField;

        private EnergiatodistusIlmoitusEnergiatodistusToteutunutOstoenergiankulutusOstettuEnergiaToVapaa toVapaaField;

        /// <remarks/>
        public decimal ToKaukolampoVuosikulutus
        {
            get
            {
                return this.toKaukolampoVuosikulutusField;
            }
            set
            {
                this.toKaukolampoVuosikulutusField = value;
            }
        }

        /// <remarks/>
        public decimal ToKokonaissahkoVuosikulutus
        {
            get
            {
                return this.toKokonaissahkoVuosikulutusField;
            }
            set
            {
                this.toKokonaissahkoVuosikulutusField = value;
            }
        }

        /// <remarks/>
        public decimal ToKiinteistosahkoVuosikulutus
        {
            get
            {
                return this.toKiinteistosahkoVuosikulutusField;
            }
            set
            {
                this.toKiinteistosahkoVuosikulutusField = value;
            }
        }

        /// <remarks/>
        public decimal ToKayttajasahkoVuosikulutus
        {
            get
            {
                return this.toKayttajasahkoVuosikulutusField;
            }
            set
            {
                this.toKayttajasahkoVuosikulutusField = value;
            }
        }

        /// <remarks/>
        public decimal ToKaukojaahdytysVuosikulutus
        {
            get
            {
                return this.toKaukojaahdytysVuosikulutusField;
            }
            set
            {
                this.toKaukojaahdytysVuosikulutusField = value;
            }
        }

        /// <remarks/>
        public EnergiatodistusIlmoitusEnergiatodistusToteutunutOstoenergiankulutusOstettuEnergiaToVapaa ToVapaa
        {
            get
            {
                return this.toVapaaField;
            }
            set
            {
                this.toVapaaField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.energiatodistusrekisteri.fi/ws/energiatodistustypes")]
    public partial class EnergiatodistusIlmoitusEnergiatodistusToteutunutOstoenergiankulutusOstettuEnergiaToVapaa
    {

        private string nimiField;

        private decimal vuosikulutusField;

        /// <remarks/>
        public string Nimi
        {
            get
            {
                return this.nimiField;
            }
            set
            {
                this.nimiField = value;
            }
        }

        /// <remarks/>
        public decimal Vuosikulutus
        {
            get
            {
                return this.vuosikulutusField;
            }
            set
            {
                this.vuosikulutusField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.energiatodistusrekisteri.fi/ws/energiatodistustypes")]
    public partial class EnergiatodistusIlmoitusEnergiatodistusToteutunutOstoenergiankulutusOpVapaa
    {

        private string opNimiField;

        private string opYksikkoField;

        private decimal opMuunnoskerroinField;

        private decimal opMaaraVuodessaField;

        /// <remarks/>
        public string OpNimi
        {
            get
            {
                return this.opNimiField;
            }
            set
            {
                this.opNimiField = value;
            }
        }

        /// <remarks/>
        public string OpYksikko
        {
            get
            {
                return this.opYksikkoField;
            }
            set
            {
                this.opYksikkoField = value;
            }
        }

        /// <remarks/>
        public decimal OpMuunnoskerroin
        {
            get
            {
                return this.opMuunnoskerroinField;
            }
            set
            {
                this.opMuunnoskerroinField = value;
            }
        }

        /// <remarks/>
        public decimal OpMaaraVuodessa
        {
            get
            {
                return this.opMaaraVuodessaField;
            }
            set
            {
                this.opMaaraVuodessaField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.energiatodistusrekisteri.fi/ws/energiatodistustypes")]
    public partial class EnergiatodistusIlmoitusEnergiatodistusHuomiot
    {

        private EnergiatodistusIlmoitusEnergiatodistusHuomiotHuomiotYmparys huomiotYmparysField;

        private EnergiatodistusIlmoitusEnergiatodistusHuomiotHuomiotAlapohjaYlapohja huomiotAlapohjaYlapohjaField;

        private EnergiatodistusIlmoitusEnergiatodistusHuomiotHuomiotLammitys huomiotLammitysField;

        private EnergiatodistusIlmoitusEnergiatodistusHuomiotHuomiotIvIlmastointi huomiotIvIlmastointiField;

        private EnergiatodistusIlmoitusEnergiatodistusHuomiotHuomiotValaistusMuut huomiotValaistusMuutField;

        private string huomiotSuositukset_FiField;

        private string huomiotSuositukset_SvField;

        private string huomiotLisatietoja_FiField;

        private string huomiotLisatietoja_SvField;

        /// <remarks/>
        public EnergiatodistusIlmoitusEnergiatodistusHuomiotHuomiotYmparys HuomiotYmparys
        {
            get
            {
                return this.huomiotYmparysField;
            }
            set
            {
                this.huomiotYmparysField = value;
            }
        }

        /// <remarks/>
        public EnergiatodistusIlmoitusEnergiatodistusHuomiotHuomiotAlapohjaYlapohja HuomiotAlapohjaYlapohja
        {
            get
            {
                return this.huomiotAlapohjaYlapohjaField;
            }
            set
            {
                this.huomiotAlapohjaYlapohjaField = value;
            }
        }

        /// <remarks/>
        public EnergiatodistusIlmoitusEnergiatodistusHuomiotHuomiotLammitys HuomiotLammitys
        {
            get
            {
                return this.huomiotLammitysField;
            }
            set
            {
                this.huomiotLammitysField = value;
            }
        }

        /// <remarks/>
        public EnergiatodistusIlmoitusEnergiatodistusHuomiotHuomiotIvIlmastointi HuomiotIvIlmastointi
        {
            get
            {
                return this.huomiotIvIlmastointiField;
            }
            set
            {
                this.huomiotIvIlmastointiField = value;
            }
        }

        /// <remarks/>
        public EnergiatodistusIlmoitusEnergiatodistusHuomiotHuomiotValaistusMuut HuomiotValaistusMuut
        {
            get
            {
                return this.huomiotValaistusMuutField;
            }
            set
            {
                this.huomiotValaistusMuutField = value;
            }
        }

        /// <remarks/>
        public string HuomiotSuositukset_Fi
        {
            get
            {
                return this.huomiotSuositukset_FiField;
            }
            set
            {
                this.huomiotSuositukset_FiField = value;
            }
        }

        /// <remarks/>
        public string HuomiotSuositukset_Sv
        {
            get
            {
                return this.huomiotSuositukset_SvField;
            }
            set
            {
                this.huomiotSuositukset_SvField = value;
            }
        }

        /// <remarks/>
        public string HuomiotLisatietoja_Fi
        {
            get
            {
                return this.huomiotLisatietoja_FiField;
            }
            set
            {
                this.huomiotLisatietoja_FiField = value;
            }
        }

        /// <remarks/>
        public string HuomiotLisatietoja_Sv
        {
            get
            {
                return this.huomiotLisatietoja_SvField;
            }
            set
            {
                this.huomiotLisatietoja_SvField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.energiatodistusrekisteri.fi/ws/energiatodistustypes")]
    public partial class EnergiatodistusIlmoitusEnergiatodistusHuomiotHuomiotYmparys
    {

        private string huomiotTeksti_FiField;

        private string huomiotTeksti_SvField;

        private EnergiatodistusIlmoitusEnergiatodistusHuomiotHuomiotYmparysToimenpide[] toimenpideField;

        /// <remarks/>
        public string HuomiotTeksti_Fi
        {
            get
            {
                return this.huomiotTeksti_FiField;
            }
            set
            {
                this.huomiotTeksti_FiField = value;
            }
        }

        /// <remarks/>
        public string HuomiotTeksti_Sv
        {
            get
            {
                return this.huomiotTeksti_SvField;
            }
            set
            {
                this.huomiotTeksti_SvField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Toimenpide")]
        public EnergiatodistusIlmoitusEnergiatodistusHuomiotHuomiotYmparysToimenpide[] Toimenpide
        {
            get
            {
                return this.toimenpideField;
            }
            set
            {
                this.toimenpideField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.energiatodistusrekisteri.fi/ws/energiatodistustypes")]
    public partial class EnergiatodistusIlmoitusEnergiatodistusHuomiotHuomiotYmparysToimenpide
    {

        private string nimi_FiField;

        private string nimi_SvField;

        private decimal lampoField;

        private decimal sahkoField;

        private decimal jaahdytysField;

        private decimal eluvunMuutosField;

        /// <remarks/>
        public string Nimi_Fi
        {
            get
            {
                return this.nimi_FiField;
            }
            set
            {
                this.nimi_FiField = value;
            }
        }

        /// <remarks/>
        public string Nimi_Sv
        {
            get
            {
                return this.nimi_SvField;
            }
            set
            {
                this.nimi_SvField = value;
            }
        }

        /// <remarks/>
        public decimal Lampo
        {
            get
            {
                return this.lampoField;
            }
            set
            {
                this.lampoField = value;
            }
        }

        /// <remarks/>
        public decimal Sahko
        {
            get
            {
                return this.sahkoField;
            }
            set
            {
                this.sahkoField = value;
            }
        }

        /// <remarks/>
        public decimal Jaahdytys
        {
            get
            {
                return this.jaahdytysField;
            }
            set
            {
                this.jaahdytysField = value;
            }
        }

        /// <remarks/>
        public decimal EluvunMuutos
        {
            get
            {
                return this.eluvunMuutosField;
            }
            set
            {
                this.eluvunMuutosField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.energiatodistusrekisteri.fi/ws/energiatodistustypes")]
    public partial class EnergiatodistusIlmoitusEnergiatodistusHuomiotHuomiotAlapohjaYlapohja
    {

        private string huomiotTeksti_FiField;

        private string huomiotTeksti_SvField;

        private EnergiatodistusIlmoitusEnergiatodistusHuomiotHuomiotAlapohjaYlapohjaToimenpide[] toimenpideField;

        /// <remarks/>
        public string HuomiotTeksti_Fi
        {
            get
            {
                return this.huomiotTeksti_FiField;
            }
            set
            {
                this.huomiotTeksti_FiField = value;
            }
        }

        /// <remarks/>
        public string HuomiotTeksti_Sv
        {
            get
            {
                return this.huomiotTeksti_SvField;
            }
            set
            {
                this.huomiotTeksti_SvField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Toimenpide")]
        public EnergiatodistusIlmoitusEnergiatodistusHuomiotHuomiotAlapohjaYlapohjaToimenpide[] Toimenpide
        {
            get
            {
                return this.toimenpideField;
            }
            set
            {
                this.toimenpideField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.energiatodistusrekisteri.fi/ws/energiatodistustypes")]
    public partial class EnergiatodistusIlmoitusEnergiatodistusHuomiotHuomiotAlapohjaYlapohjaToimenpide
    {

        private string nimi_FiField;

        private string nimi_SvField;

        private decimal lampoField;

        private decimal sahkoField;

        private decimal jaahdytysField;

        private decimal eluvunMuutosField;

        /// <remarks/>
        public string Nimi_Fi
        {
            get
            {
                return this.nimi_FiField;
            }
            set
            {
                this.nimi_FiField = value;
            }
        }

        /// <remarks/>
        public string Nimi_Sv
        {
            get
            {
                return this.nimi_SvField;
            }
            set
            {
                this.nimi_SvField = value;
            }
        }

        /// <remarks/>
        public decimal Lampo
        {
            get
            {
                return this.lampoField;
            }
            set
            {
                this.lampoField = value;
            }
        }

        /// <remarks/>
        public decimal Sahko
        {
            get
            {
                return this.sahkoField;
            }
            set
            {
                this.sahkoField = value;
            }
        }

        /// <remarks/>
        public decimal Jaahdytys
        {
            get
            {
                return this.jaahdytysField;
            }
            set
            {
                this.jaahdytysField = value;
            }
        }

        /// <remarks/>
        public decimal EluvunMuutos
        {
            get
            {
                return this.eluvunMuutosField;
            }
            set
            {
                this.eluvunMuutosField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.energiatodistusrekisteri.fi/ws/energiatodistustypes")]
    public partial class EnergiatodistusIlmoitusEnergiatodistusHuomiotHuomiotLammitys
    {

        private string huomiotTeksti_FiField;

        private string huomiotTeksti_SvField;

        private EnergiatodistusIlmoitusEnergiatodistusHuomiotHuomiotLammitysToimenpide[] toimenpideField;

        /// <remarks/>
        public string HuomiotTeksti_Fi
        {
            get
            {
                return this.huomiotTeksti_FiField;
            }
            set
            {
                this.huomiotTeksti_FiField = value;
            }
        }

        /// <remarks/>
        public string HuomiotTeksti_Sv
        {
            get
            {
                return this.huomiotTeksti_SvField;
            }
            set
            {
                this.huomiotTeksti_SvField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Toimenpide")]
        public EnergiatodistusIlmoitusEnergiatodistusHuomiotHuomiotLammitysToimenpide[] Toimenpide
        {
            get
            {
                return this.toimenpideField;
            }
            set
            {
                this.toimenpideField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.energiatodistusrekisteri.fi/ws/energiatodistustypes")]
    public partial class EnergiatodistusIlmoitusEnergiatodistusHuomiotHuomiotLammitysToimenpide
    {

        private string nimi_FiField;

        private string nimi_SvField;

        private decimal lampoField;

        private decimal sahkoField;

        private decimal jaahdytysField;

        private decimal eluvunMuutosField;

        /// <remarks/>
        public string Nimi_Fi
        {
            get
            {
                return this.nimi_FiField;
            }
            set
            {
                this.nimi_FiField = value;
            }
        }

        /// <remarks/>
        public string Nimi_Sv
        {
            get
            {
                return this.nimi_SvField;
            }
            set
            {
                this.nimi_SvField = value;
            }
        }

        /// <remarks/>
        public decimal Lampo
        {
            get
            {
                return this.lampoField;
            }
            set
            {
                this.lampoField = value;
            }
        }

        /// <remarks/>
        public decimal Sahko
        {
            get
            {
                return this.sahkoField;
            }
            set
            {
                this.sahkoField = value;
            }
        }

        /// <remarks/>
        public decimal Jaahdytys
        {
            get
            {
                return this.jaahdytysField;
            }
            set
            {
                this.jaahdytysField = value;
            }
        }

        /// <remarks/>
        public decimal EluvunMuutos
        {
            get
            {
                return this.eluvunMuutosField;
            }
            set
            {
                this.eluvunMuutosField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.energiatodistusrekisteri.fi/ws/energiatodistustypes")]
    public partial class EnergiatodistusIlmoitusEnergiatodistusHuomiotHuomiotIvIlmastointi
    {

        private string huomiotTeksti_FiField;

        private string huomiotTeksti_SvField;

        private EnergiatodistusIlmoitusEnergiatodistusHuomiotHuomiotIvIlmastointiToimenpide[] toimenpideField;

        /// <remarks/>
        public string HuomiotTeksti_Fi
        {
            get
            {
                return this.huomiotTeksti_FiField;
            }
            set
            {
                this.huomiotTeksti_FiField = value;
            }
        }

        /// <remarks/>
        public string HuomiotTeksti_Sv
        {
            get
            {
                return this.huomiotTeksti_SvField;
            }
            set
            {
                this.huomiotTeksti_SvField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Toimenpide")]
        public EnergiatodistusIlmoitusEnergiatodistusHuomiotHuomiotIvIlmastointiToimenpide[] Toimenpide
        {
            get
            {
                return this.toimenpideField;
            }
            set
            {
                this.toimenpideField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.energiatodistusrekisteri.fi/ws/energiatodistustypes")]
    public partial class EnergiatodistusIlmoitusEnergiatodistusHuomiotHuomiotIvIlmastointiToimenpide
    {

        private string nimi_FiField;

        private string nimi_SvField;

        private decimal lampoField;

        private decimal sahkoField;

        private decimal jaahdytysField;

        private decimal eluvunMuutosField;

        /// <remarks/>
        public string Nimi_Fi
        {
            get
            {
                return this.nimi_FiField;
            }
            set
            {
                this.nimi_FiField = value;
            }
        }

        /// <remarks/>
        public string Nimi_Sv
        {
            get
            {
                return this.nimi_SvField;
            }
            set
            {
                this.nimi_SvField = value;
            }
        }

        /// <remarks/>
        public decimal Lampo
        {
            get
            {
                return this.lampoField;
            }
            set
            {
                this.lampoField = value;
            }
        }

        /// <remarks/>
        public decimal Sahko
        {
            get
            {
                return this.sahkoField;
            }
            set
            {
                this.sahkoField = value;
            }
        }

        /// <remarks/>
        public decimal Jaahdytys
        {
            get
            {
                return this.jaahdytysField;
            }
            set
            {
                this.jaahdytysField = value;
            }
        }

        /// <remarks/>
        public decimal EluvunMuutos
        {
            get
            {
                return this.eluvunMuutosField;
            }
            set
            {
                this.eluvunMuutosField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.energiatodistusrekisteri.fi/ws/energiatodistustypes")]
    public partial class EnergiatodistusIlmoitusEnergiatodistusHuomiotHuomiotValaistusMuut
    {

        private string huomiotTeksti_FiField;

        private string huomiotTeksti_SvField;

        private EnergiatodistusIlmoitusEnergiatodistusHuomiotHuomiotValaistusMuutToimenpide[] toimenpideField;

        /// <remarks/>
        public string HuomiotTeksti_Fi
        {
            get
            {
                return this.huomiotTeksti_FiField;
            }
            set
            {
                this.huomiotTeksti_FiField = value;
            }
        }

        /// <remarks/>
        public string HuomiotTeksti_Sv
        {
            get
            {
                return this.huomiotTeksti_SvField;
            }
            set
            {
                this.huomiotTeksti_SvField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Toimenpide")]
        public EnergiatodistusIlmoitusEnergiatodistusHuomiotHuomiotValaistusMuutToimenpide[] Toimenpide
        {
            get
            {
                return this.toimenpideField;
            }
            set
            {
                this.toimenpideField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.energiatodistusrekisteri.fi/ws/energiatodistustypes")]
    public partial class EnergiatodistusIlmoitusEnergiatodistusHuomiotHuomiotValaistusMuutToimenpide
    {

        private string nimi_FiField;

        private string nimi_SvField;

        private decimal lampoField;

        private decimal sahkoField;

        private decimal jaahdytysField;

        private decimal eluvunMuutosField;

        /// <remarks/>
        public string Nimi_Fi
        {
            get
            {
                return this.nimi_FiField;
            }
            set
            {
                this.nimi_FiField = value;
            }
        }

        /// <remarks/>
        public string Nimi_Sv
        {
            get
            {
                return this.nimi_SvField;
            }
            set
            {
                this.nimi_SvField = value;
            }
        }

        /// <remarks/>
        public decimal Lampo
        {
            get
            {
                return this.lampoField;
            }
            set
            {
                this.lampoField = value;
            }
        }

        /// <remarks/>
        public decimal Sahko
        {
            get
            {
                return this.sahkoField;
            }
            set
            {
                this.sahkoField = value;
            }
        }

        /// <remarks/>
        public decimal Jaahdytys
        {
            get
            {
                return this.jaahdytysField;
            }
            set
            {
                this.jaahdytysField = value;
            }
        }

        /// <remarks/>
        public decimal EluvunMuutos
        {
            get
            {
                return this.eluvunMuutosField;
            }
            set
            {
                this.eluvunMuutosField = value;
            }
        }
    }


}
