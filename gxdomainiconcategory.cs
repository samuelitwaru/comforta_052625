using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class gxdomainiconcategory
   {
      private static Hashtable domain = new Hashtable();
      private static Hashtable domainMap;
      static gxdomainiconcategory ()
      {
         domain["General"] = "General";
         domain["Services"] = "Services";
         domain["Living"] = "Living";
         domain["Health"] = "Health";
         domain["Technical Services & Support"] = "Technical Services & Support";
         domain["Care & Wellbeing"] = "Care & Wellbeing";
         domain["Services & Hospitality"] = "Services & Hospitality";
         domain["Community & Connection"] = "Community & Connection";
         domain["Communication & Media"] = "Communication & Media";
         domain["Building & Furnishing"] = "Building & Furnishing";
         domain["Mobility & Transport"] = "Mobility & Transport";
         domain["Real Estate & Rental"] = "Real Estate & Rental";
      }

      public static string getDescription( IGxContext context ,
                                           string key )
      {
         string rtkey;
         string value;
         rtkey = ((key==null) ? "" : StringUtil.Trim( (string)(key)));
         value = (string)(domain[rtkey]==null?"":domain[rtkey]);
         return context.GetMessage( value, "") ;
      }

      public static GxSimpleCollection<string> getValues( )
      {
         GxSimpleCollection<string> value = new GxSimpleCollection<string>();
         ArrayList aKeys = new ArrayList(domain.Keys);
         aKeys.Sort();
         foreach (string key in aKeys)
         {
            value.Add(key);
         }
         return value;
      }

      public static string getValue( string key )
      {
         if(domainMap == null)
         {
            domainMap = new Hashtable();
            domainMap["General"] = "General";
            domainMap["Services"] = "Services";
            domainMap["Living"] = "Living";
            domainMap["Health"] = "Health";
            domainMap["TechnicalServicesAndSupport"] = "Technical Services & Support";
            domainMap["CareAndWellbeing"] = "Care & Wellbeing";
            domainMap["ServicesAndHospitality"] = "Services & Hospitality";
            domainMap["CommunityAndConnection"] = "Community & Connection";
            domainMap["CommunicationAndMedia"] = "Communication & Media";
            domainMap["BuildingAndFurnishing"] = "Building & Furnishing";
            domainMap["MobilityAndTransport"] = "Mobility & Transport";
            domainMap["RealEstateAndRental"] = "Real Estate & Rental";
         }
         return (string)domainMap[key] ;
      }

   }

}
