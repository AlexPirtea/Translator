using System;
using System.Collections.Generic;
using System.Text;

namespace Translator.Model
{
    // NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class TRANSLATIONS
    {

        private TRANSLATIONSRECORD[] rECORDField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("RECORD")]
        public TRANSLATIONSRECORD[] RECORD
        {
            get
            {
                return this.rECORDField;
            }
            set
            {
                this.rECORDField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class TRANSLATIONSRECORD
    {

        private TRANSLATIONSRECORDLINK[] lINKField;

        private string wordField;

        private string cultureField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("LINK")]
        public TRANSLATIONSRECORDLINK[] LINK
        {
            get
            {
                return this.lINKField;
            }
            set
            {
                this.lINKField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string word
        {
            get
            {
                return this.wordField;
            }
            set
            {
                this.wordField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string culture
        {
            get
            {
                return this.cultureField;
            }
            set
            {
                this.cultureField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class TRANSLATIONSRECORDLINK
    {

        private string wordField;

        private string cultureField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string word
        {
            get
            {
                return this.wordField;
            }
            set
            {
                this.wordField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string culture
        {
            get
            {
                return this.cultureField;
            }
            set
            {
                this.cultureField = value;
            }
        }
    }


}
