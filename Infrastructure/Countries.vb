Option Strict On

' ----------------------------------------------------
' GENERATED CODE
' Generated with Countries.cst inside CodeSmith Studio
' ----------------------------------------------------

Imports System.Globalization
Imports Mbark.CountryMessages

Namespace Mbark

    <Serializable()> Public Class CountryData

        Private Sub New()
            ' Forbid construction
        End Sub

        Public Sub New( _
         ByVal messageKey As String, _
         ByVal fips104Alpha2 As String, _
         ByVal iso3166Alpha2 As String, _
         ByVal iso3166Alpha3 As String, _
         ByVal iso3166Digit3 As String, _
         ByVal internetSuffix As String, _
         ByVal dialingCountryCodes() As String, _
         ByVal iddPrefixes() As String, _
         ByVal nddPrefixes() As String)

            mMessageKey = messageKey
            mFIPS104Alpha2 = fips104Alpha2
            mISO3166Alpha2 = iso3166Alpha2
            mISO3166Alpha3 = iso3166Alpha3
            mISO3166Digit3 = iso3166Digit3
            mInternetSuffix = internetSuffix
            mDialingCountryCodes = dialingCountryCodes
            mIddPrefixes = iddPrefixes
            mNddPrefixes = nddPrefixes

        End Sub

        Private mMessageKey As String
        Private mFips104Alpha2 As String
        Private mIso3166Alpha2 As String
        Private mIso3166Alpha3 As String
        Private mIso3166Digit3 As String
        Private mInternetSuffix As String
        Private mDialingCountryCodes() As String
        Private mIddPrefixes() As String
        Private mNddPrefixes() As String

        Public ReadOnly Property Fips104Alpha2() As String
            Get
                Return mFips104Alpha2
            End Get
        End Property

        Public ReadOnly Property Iso3166Alpha2() As String
            Get
                Return mIso3166Alpha2
            End Get
        End Property

        Public ReadOnly Property Iso3166Alpha3() As String
            Get
                Return mIso3166Alpha3
            End Get
        End Property

        Public ReadOnly Property Iso3166Digit3() As String
            Get
                Return mIso3166Digit3
            End Get
        End Property

        Public ReadOnly Property Name(ByVal culture As CultureInfo) As String
            Get
                Return Messages.GetString(culture, mMessageKey)
            End Get
        End Property

        Public ReadOnly Property InternetSuffix() As String
            Get
                Return mInternetSuffix
            End Get
        End Property

        Public Function DialingCountryCodes() As String()
            Return mDialingCountryCodes
        End Function

        Public Function NddPrefixes() As String()
            Return mNddPrefixes
        End Function

        Public Function IddPrefixes() As String()
            Return mIddPrefixes
        End Function

        Public Overloads Overrides Function ToString() As String
            Return Name(CultureInfo.CurrentUICulture)
        End Function

        Public Overloads Function ToString(ByVal culture As CultureInfo) As String
            Return Name(culture)
        End Function



    End Class

    Public NotInheritable Class Countries
        Private Shared ReadOnly smAfghanistan As CountryData = InitializeAfghanistan()
        Private Shared ReadOnly smAfghanistanCountryCodes As String() = {"+93"}
        Private Shared ReadOnly smAfghanistanIdds As String() = {"00"}
        Private Shared ReadOnly smAfghanistanNdds As String() = {"0"}
        Private Shared Function InitializeAfghanistan() As CountryData
            Dim country As New CountryData( _
             "Afghanistan", "AF", "AF", "AFG", "004", "af", _
             smAfghanistanCountryCodes, _
             smAfghanistanIdds, _
             smAfghanistanNdds)
            Return country
        End Function

        Private Shared ReadOnly smAlbania As CountryData = InitializeAlbania()
        Private Shared ReadOnly smAlbaniaCountryCodes As String() = {"+355"}
        Private Shared ReadOnly smAlbaniaIdds As String() = {"00"}
        Private Shared ReadOnly smAlbaniaNdds As String() = {"0"}
        Private Shared Function InitializeAlbania() As CountryData
            Dim country As New CountryData( _
             "Albania", "AL", "AL", "ALB", "008", "al", _
             smAlbaniaCountryCodes, _
             smAlbaniaIdds, _
             smAlbaniaNdds)
            Return country
        End Function

        Private Shared ReadOnly smAlgeria As CountryData = InitializeAlgeria()
        Private Shared ReadOnly smAlgeriaCountryCodes As String() = {"+213"}
        Private Shared ReadOnly smAlgeriaIdds As String() = {"00"}
        Private Shared ReadOnly smAlgeriaNdds As String() = {"7"}
        Private Shared Function InitializeAlgeria() As CountryData
            Dim country As New CountryData( _
             "Algeria", "AG", "DZ", "DZA", "012", "dz", _
             smAlgeriaCountryCodes, _
             smAlgeriaIdds, _
             smAlgeriaNdds)
            Return country
        End Function

        Private Shared ReadOnly smAmericanSamoa As CountryData = InitializeAmericanSamoa()
        Private Shared ReadOnly smAmericanSamoaCountryCodes As String() = {"+684"}
        Private Shared ReadOnly smAmericanSamoaIdds As String() = {"00"}
        Private Shared ReadOnly smAmericanSamoaNdds As String() = {}
        Private Shared Function InitializeAmericanSamoa() As CountryData
            Dim country As New CountryData( _
             "AmericanSamoa", "AQ", "AS", "ASM", "016", "as", _
             smAmericanSamoaCountryCodes, _
             smAmericanSamoaIdds, _
             smAmericanSamoaNdds)
            Return country
        End Function

        Private Shared ReadOnly smAndorra As CountryData = InitializeAndorra()
        Private Shared ReadOnly smAndorraCountryCodes As String() = {"+376"}
        Private Shared ReadOnly smAndorraIdds As String() = {"00"}
        Private Shared ReadOnly smAndorraNdds As String() = {}
        Private Shared Function InitializeAndorra() As CountryData
            Dim country As New CountryData( _
             "Andorra", "AN", "AD", "AND", "020", "ad", _
             smAndorraCountryCodes, _
             smAndorraIdds, _
             smAndorraNdds)
            Return country
        End Function

        Private Shared ReadOnly smAngola As CountryData = InitializeAngola()
        Private Shared ReadOnly smAngolaCountryCodes As String() = {"+244"}
        Private Shared ReadOnly smAngolaIdds As String() = {"00"}
        Private Shared ReadOnly smAngolaNdds As String() = {"0"}
        Private Shared Function InitializeAngola() As CountryData
            Dim country As New CountryData( _
             "Angola", "AO", "AO", "AGO", "024", "ao", _
             smAngolaCountryCodes, _
             smAngolaIdds, _
             smAngolaNdds)
            Return country
        End Function

        Private Shared ReadOnly smAnguilla As CountryData = InitializeAnguilla()
        Private Shared ReadOnly smAnguillaCountryCodes As String() = {"+1-264"}
        Private Shared ReadOnly smAnguillaIdds As String() = {"011"}
        Private Shared ReadOnly smAnguillaNdds As String() = {"1"}
        Private Shared Function InitializeAnguilla() As CountryData
            Dim country As New CountryData( _
             "Anguilla", "AV", "AI", "AIA", "660", "ai", _
             smAnguillaCountryCodes, _
             smAnguillaIdds, _
             smAnguillaNdds)
            Return country
        End Function

        Private Shared ReadOnly smAntarctica As CountryData = InitializeAntarctica()
        Private Shared ReadOnly smAntarcticaCountryCodes As String() = {"+672"}
        Private Shared ReadOnly smAntarcticaIdds As String() = {}
        Private Shared ReadOnly smAntarcticaNdds As String() = {}
        Private Shared Function InitializeAntarctica() As CountryData
            Dim country As New CountryData( _
             "Antarctica", "AY", "AQ", "ATA", "010", "aq", _
             smAntarcticaCountryCodes, _
             smAntarcticaIdds, _
             smAntarcticaNdds)
            Return country
        End Function

        Private Shared ReadOnly smAntiguaBarbuda As CountryData = InitializeAntiguaBarbuda()
        Private Shared ReadOnly smAntiguaBarbudaCountryCodes As String() = {"+1-268"}
        Private Shared ReadOnly smAntiguaBarbudaIdds As String() = {"011"}
        Private Shared ReadOnly smAntiguaBarbudaNdds As String() = {"1"}
        Private Shared Function InitializeAntiguaBarbuda() As CountryData
            Dim country As New CountryData( _
             "AntiguaBarbuda", "AC", "AG", "ATG", "28", "ag", _
             smAntiguaBarbudaCountryCodes, _
             smAntiguaBarbudaIdds, _
             smAntiguaBarbudaNdds)
            Return country
        End Function

        Private Shared ReadOnly smArgentina As CountryData = InitializeArgentina()
        Private Shared ReadOnly smArgentinaCountryCodes As String() = {"+54"}
        Private Shared ReadOnly smArgentinaIdds As String() = {"00"}
        Private Shared ReadOnly smArgentinaNdds As String() = {"0"}
        Private Shared Function InitializeArgentina() As CountryData
            Dim country As New CountryData( _
             "Argentina", "AR", "AR", "ARG", "032", "ar", _
             smArgentinaCountryCodes, _
             smArgentinaIdds, _
             smArgentinaNdds)
            Return country
        End Function

        Private Shared ReadOnly smArmenia As CountryData = InitializeArmenia()
        Private Shared ReadOnly smArmeniaCountryCodes As String() = {"+374"}
        Private Shared ReadOnly smArmeniaIdds As String() = {"00"}
        Private Shared ReadOnly smArmeniaNdds As String() = {"8"}
        Private Shared Function InitializeArmenia() As CountryData
            Dim country As New CountryData( _
             "Armenia", "AM", "AM", "ARM", "051", "am", _
             smArmeniaCountryCodes, _
             smArmeniaIdds, _
             smArmeniaNdds)
            Return country
        End Function

        Private Shared ReadOnly smAruba As CountryData = InitializeAruba()
        Private Shared ReadOnly smArubaCountryCodes As String() = {"+297"}
        Private Shared ReadOnly smArubaIdds As String() = {"00"}
        Private Shared ReadOnly smArubaNdds As String() = {}
        Private Shared Function InitializeAruba() As CountryData
            Dim country As New CountryData( _
             "Aruba", "AA", "AW", "ABW", "533", "aw", _
             smArubaCountryCodes, _
             smArubaIdds, _
             smArubaNdds)
            Return country
        End Function

        Private Shared ReadOnly smAustralia As CountryData = InitializeAustralia()
        Private Shared ReadOnly smAustraliaCountryCodes As String() = {"+61"}
        Private Shared ReadOnly smAustraliaIdds As String() = {"0011", "0015"}
        Private Shared ReadOnly smAustraliaNdds As String() = {"0"}
        Private Shared Function InitializeAustralia() As CountryData
            Dim country As New CountryData( _
             "Australia", "AS", "AU", "AUS", "036", "au", _
             smAustraliaCountryCodes, _
             smAustraliaIdds, _
             smAustraliaNdds)
            Return country
        End Function

        Private Shared ReadOnly smAustria As CountryData = InitializeAustria()
        Private Shared ReadOnly smAustriaCountryCodes As String() = {"+43"}
        Private Shared ReadOnly smAustriaIdds As String() = {"00"}
        Private Shared ReadOnly smAustriaNdds As String() = {"0"}
        Private Shared Function InitializeAustria() As CountryData
            Dim country As New CountryData( _
             "Austria", "AU", "AT", "AUT", "040", "at", _
             smAustriaCountryCodes, _
             smAustriaIdds, _
             smAustriaNdds)
            Return country
        End Function

        Private Shared ReadOnly smAzerbaijan As CountryData = InitializeAzerbaijan()
        Private Shared ReadOnly smAzerbaijanCountryCodes As String() = {"+994"}
        Private Shared ReadOnly smAzerbaijanIdds As String() = {"00"}
        Private Shared ReadOnly smAzerbaijanNdds As String() = {"8"}
        Private Shared Function InitializeAzerbaijan() As CountryData
            Dim country As New CountryData( _
             "Azerbaijan", "AJ", "AZ", "AZE", "031", "az", _
             smAzerbaijanCountryCodes, _
             smAzerbaijanIdds, _
             smAzerbaijanNdds)
            Return country
        End Function

        Private Shared ReadOnly smBahamas As CountryData = InitializeBahamas()
        Private Shared ReadOnly smBahamasCountryCodes As String() = {"+1-242"}
        Private Shared ReadOnly smBahamasIdds As String() = {"011"}
        Private Shared ReadOnly smBahamasNdds As String() = {"1"}
        Private Shared Function InitializeBahamas() As CountryData
            Dim country As New CountryData( _
             "Bahamas", "BF", "BS", "BHS", "044", "bs", _
             smBahamasCountryCodes, _
             smBahamasIdds, _
             smBahamasNdds)
            Return country
        End Function

        Private Shared ReadOnly smBahrain As CountryData = InitializeBahrain()
        Private Shared ReadOnly smBahrainCountryCodes As String() = {"+973"}
        Private Shared ReadOnly smBahrainIdds As String() = {"00"}
        Private Shared ReadOnly smBahrainNdds As String() = {}
        Private Shared Function InitializeBahrain() As CountryData
            Dim country As New CountryData( _
             "Bahrain", "BA", "BH", "BHR", "048", "bh", _
             smBahrainCountryCodes, _
             smBahrainIdds, _
             smBahrainNdds)
            Return country
        End Function

        Private Shared ReadOnly smBangladesh As CountryData = InitializeBangladesh()
        Private Shared ReadOnly smBangladeshCountryCodes As String() = {"+880"}
        Private Shared ReadOnly smBangladeshIdds As String() = {"00"}
        Private Shared ReadOnly smBangladeshNdds As String() = {"0"}
        Private Shared Function InitializeBangladesh() As CountryData
            Dim country As New CountryData( _
             "Bangladesh", "BG", "BD", "BGD", "050", "bd", _
             smBangladeshCountryCodes, _
             smBangladeshIdds, _
             smBangladeshNdds)
            Return country
        End Function

        Private Shared ReadOnly smBarbados As CountryData = InitializeBarbados()
        Private Shared ReadOnly smBarbadosCountryCodes As String() = {"+1-246"}
        Private Shared ReadOnly smBarbadosIdds As String() = {"011"}
        Private Shared ReadOnly smBarbadosNdds As String() = {"1"}
        Private Shared Function InitializeBarbados() As CountryData
            Dim country As New CountryData( _
             "Barbados", "BB", "BB", "BRB", "052", "bb", _
             smBarbadosCountryCodes, _
             smBarbadosIdds, _
             smBarbadosNdds)
            Return country
        End Function

        Private Shared ReadOnly smBelarus As CountryData = InitializeBelarus()
        Private Shared ReadOnly smBelarusCountryCodes As String() = {"+375"}
        Private Shared ReadOnly smBelarusIdds As String() = {"8~10"}
        Private Shared ReadOnly smBelarusNdds As String() = {"8"}
        Private Shared Function InitializeBelarus() As CountryData
            Dim country As New CountryData( _
             "Belarus", "BO", "BY", "BLR", "112", "by", _
             smBelarusCountryCodes, _
             smBelarusIdds, _
             smBelarusNdds)
            Return country
        End Function

        Private Shared ReadOnly smBelgium As CountryData = InitializeBelgium()
        Private Shared ReadOnly smBelgiumCountryCodes As String() = {"+32"}
        Private Shared ReadOnly smBelgiumIdds As String() = {"00"}
        Private Shared ReadOnly smBelgiumNdds As String() = {"0"}
        Private Shared Function InitializeBelgium() As CountryData
            Dim country As New CountryData( _
             "Belgium", "BE", "BE", "BEL", "056", "be", _
             smBelgiumCountryCodes, _
             smBelgiumIdds, _
             smBelgiumNdds)
            Return country
        End Function

        Private Shared ReadOnly smBelize As CountryData = InitializeBelize()
        Private Shared ReadOnly smBelizeCountryCodes As String() = {"+501"}
        Private Shared ReadOnly smBelizeIdds As String() = {"00"}
        Private Shared ReadOnly smBelizeNdds As String() = {"0"}
        Private Shared Function InitializeBelize() As CountryData
            Dim country As New CountryData( _
             "Belize", "BH", "BZ", "BLZ", "084", "bz", _
             smBelizeCountryCodes, _
             smBelizeIdds, _
             smBelizeNdds)
            Return country
        End Function

        Private Shared ReadOnly smBenin As CountryData = InitializeBenin()
        Private Shared ReadOnly smBeninCountryCodes As String() = {"+229"}
        Private Shared ReadOnly smBeninIdds As String() = {"00"}
        Private Shared ReadOnly smBeninNdds As String() = {}
        Private Shared Function InitializeBenin() As CountryData
            Dim country As New CountryData( _
             "Benin", "BN", "BJ", "BEN", "204", "bj", _
             smBeninCountryCodes, _
             smBeninIdds, _
             smBeninNdds)
            Return country
        End Function

        Private Shared ReadOnly smBermuda As CountryData = InitializeBermuda()
        Private Shared ReadOnly smBermudaCountryCodes As String() = {"+1-441"}
        Private Shared ReadOnly smBermudaIdds As String() = {"011"}
        Private Shared ReadOnly smBermudaNdds As String() = {"1"}
        Private Shared Function InitializeBermuda() As CountryData
            Dim country As New CountryData( _
             "Bermuda", "BD", "BM", "BMU", "060", "bm", _
             smBermudaCountryCodes, _
             smBermudaIdds, _
             smBermudaNdds)
            Return country
        End Function

        Private Shared ReadOnly smBhutan As CountryData = InitializeBhutan()
        Private Shared ReadOnly smBhutanCountryCodes As String() = {"+975"}
        Private Shared ReadOnly smBhutanIdds As String() = {"00"}
        Private Shared ReadOnly smBhutanNdds As String() = {}
        Private Shared Function InitializeBhutan() As CountryData
            Dim country As New CountryData( _
             "Bhutan", "BT", "BT", "BTN", "064", "bt", _
             smBhutanCountryCodes, _
             smBhutanIdds, _
             smBhutanNdds)
            Return country
        End Function

        Private Shared ReadOnly smBolivia As CountryData = InitializeBolivia()
        Private Shared ReadOnly smBoliviaCountryCodes As String() = {"+591"}
        Private Shared ReadOnly smBoliviaIdds As String() = {"0010", "0011", "0012", "0013"}
        Private Shared ReadOnly smBoliviaNdds As String() = {"010", "011", "012", "013"}
        Private Shared Function InitializeBolivia() As CountryData
            Dim country As New CountryData( _
             "Bolivia", "BL", "BO", "BOL", "068", "bo", _
             smBoliviaCountryCodes, _
             smBoliviaIdds, _
             smBoliviaNdds)
            Return country
        End Function

        Private Shared ReadOnly smBosniaHerzegovina As CountryData = InitializeBosniaHerzegovina()
        Private Shared ReadOnly smBosniaHerzegovinaCountryCodes As String() = {"+387"}
        Private Shared ReadOnly smBosniaHerzegovinaIdds As String() = {"00"}
        Private Shared ReadOnly smBosniaHerzegovinaNdds As String() = {"0"}
        Private Shared Function InitializeBosniaHerzegovina() As CountryData
            Dim country As New CountryData( _
             "BosniaHerzegovina", "BK", "BA", "BIH", "070", "ba", _
             smBosniaHerzegovinaCountryCodes, _
             smBosniaHerzegovinaIdds, _
             smBosniaHerzegovinaNdds)
            Return country
        End Function

        Private Shared ReadOnly smBotswana As CountryData = InitializeBotswana()
        Private Shared ReadOnly smBotswanaCountryCodes As String() = {"+267"}
        Private Shared ReadOnly smBotswanaIdds As String() = {"00"}
        Private Shared ReadOnly smBotswanaNdds As String() = {}
        Private Shared Function InitializeBotswana() As CountryData
            Dim country As New CountryData( _
             "Botswana", "BC", "BW", "BWA", "072", "bw", _
             smBotswanaCountryCodes, _
             smBotswanaIdds, _
             smBotswanaNdds)
            Return country
        End Function

        Private Shared ReadOnly smBouvetIsland As CountryData = InitializeBouvetIsland()
        Private Shared ReadOnly smBouvetIslandCountryCodes As String() = {}
        Private Shared ReadOnly smBouvetIslandIdds As String() = {}
        Private Shared ReadOnly smBouvetIslandNdds As String() = {}
        Private Shared Function InitializeBouvetIsland() As CountryData
            Dim country As New CountryData( _
             "BouvetIsland", "BV", "BV", "BVT", "074", "bv", _
             smBouvetIslandCountryCodes, _
             smBouvetIslandIdds, _
             smBouvetIslandNdds)
            Return country
        End Function

        Private Shared ReadOnly smBrazil As CountryData = InitializeBrazil()
        Private Shared ReadOnly smBrazilCountryCodes As String() = {"+55"}
        Private Shared ReadOnly smBrazilIdds As String() = {"0014", "0015", "0021", "0023", "0031"}
        Private Shared ReadOnly smBrazilNdds As String() = {"014", "015", "021", "023", "031", "0"}
        Private Shared Function InitializeBrazil() As CountryData
            Dim country As New CountryData( _
             "Brazil", "BR", "BR", "BRA", "076", "br", _
             smBrazilCountryCodes, _
             smBrazilIdds, _
             smBrazilNdds)
            Return country
        End Function

        Private Shared ReadOnly smBritishIndianOceanTerritory As CountryData = InitializeBritishIndianOceanTerritory()
        Private Shared ReadOnly smBritishIndianOceanTerritoryCountryCodes As String() = {}
        Private Shared ReadOnly smBritishIndianOceanTerritoryIdds As String() = {}
        Private Shared ReadOnly smBritishIndianOceanTerritoryNdds As String() = {}
        Private Shared Function InitializeBritishIndianOceanTerritory() As CountryData
            Dim country As New CountryData( _
             "BritishIndianOceanTerritory", "IO", "IO", "IOT", "86", "io", _
             smBritishIndianOceanTerritoryCountryCodes, _
             smBritishIndianOceanTerritoryIdds, _
             smBritishIndianOceanTerritoryNdds)
            Return country
        End Function

        Private Shared ReadOnly smBritishVirginIslands As CountryData = InitializeBritishVirginIslands()
        Private Shared ReadOnly smBritishVirginIslandsCountryCodes As String() = {"+1-284"}
        Private Shared ReadOnly smBritishVirginIslandsIdds As String() = {"011"}
        Private Shared ReadOnly smBritishVirginIslandsNdds As String() = {"1"}
        Private Shared Function InitializeBritishVirginIslands() As CountryData
            Dim country As New CountryData( _
             "BritishVirginIslands", "VI", "VG", "VGB", "092", "vg", _
             smBritishVirginIslandsCountryCodes, _
             smBritishVirginIslandsIdds, _
             smBritishVirginIslandsNdds)
            Return country
        End Function

        Private Shared ReadOnly smBrunei As CountryData = InitializeBrunei()
        Private Shared ReadOnly smBruneiCountryCodes As String() = {"+673"}
        Private Shared ReadOnly smBruneiIdds As String() = {"00"}
        Private Shared ReadOnly smBruneiNdds As String() = {"0"}
        Private Shared Function InitializeBrunei() As CountryData
            Dim country As New CountryData( _
             "Brunei", "BX", "BN", "BRN", "096", "bn", _
             smBruneiCountryCodes, _
             smBruneiIdds, _
             smBruneiNdds)
            Return country
        End Function

        Private Shared ReadOnly smBulgaria As CountryData = InitializeBulgaria()
        Private Shared ReadOnly smBulgariaCountryCodes As String() = {"+359"}
        Private Shared ReadOnly smBulgariaIdds As String() = {"00"}
        Private Shared ReadOnly smBulgariaNdds As String() = {"0"}
        Private Shared Function InitializeBulgaria() As CountryData
            Dim country As New CountryData( _
             "Bulgaria", "BU", "BG", "BGR", "100", "bg", _
             smBulgariaCountryCodes, _
             smBulgariaIdds, _
             smBulgariaNdds)
            Return country
        End Function

        Private Shared ReadOnly smBurkinaFaso As CountryData = InitializeBurkinaFaso()
        Private Shared ReadOnly smBurkinaFasoCountryCodes As String() = {"+226"}
        Private Shared ReadOnly smBurkinaFasoIdds As String() = {"00"}
        Private Shared ReadOnly smBurkinaFasoNdds As String() = {}
        Private Shared Function InitializeBurkinaFaso() As CountryData
            Dim country As New CountryData( _
             "BurkinaFaso", "UV", "BF", "BFA", "854", "bf", _
             smBurkinaFasoCountryCodes, _
             smBurkinaFasoIdds, _
             smBurkinaFasoNdds)
            Return country
        End Function

        Private Shared ReadOnly smBurma As CountryData = InitializeBurma()
        Private Shared ReadOnly smBurmaCountryCodes As String() = {}
        Private Shared ReadOnly smBurmaIdds As String() = {}
        Private Shared ReadOnly smBurmaNdds As String() = {}
        Private Shared Function InitializeBurma() As CountryData
            Dim country As New CountryData( _
             "Burma", "BM", "MM", "MMR", "104", "mm", _
             smBurmaCountryCodes, _
             smBurmaIdds, _
             smBurmaNdds)
            Return country
        End Function

        Private Shared ReadOnly smBurundi As CountryData = InitializeBurundi()
        Private Shared ReadOnly smBurundiCountryCodes As String() = {"+257"}
        Private Shared ReadOnly smBurundiIdds As String() = {"00"}
        Private Shared ReadOnly smBurundiNdds As String() = {}
        Private Shared Function InitializeBurundi() As CountryData
            Dim country As New CountryData( _
             "Burundi", "BY", "BI", "BDI", "108", "bi", _
             smBurundiCountryCodes, _
             smBurundiIdds, _
             smBurundiNdds)
            Return country
        End Function

        Private Shared ReadOnly smCambodia As CountryData = InitializeCambodia()
        Private Shared ReadOnly smCambodiaCountryCodes As String() = {"+855"}
        Private Shared ReadOnly smCambodiaIdds As String() = {"001"}
        Private Shared ReadOnly smCambodiaNdds As String() = {"0"}
        Private Shared Function InitializeCambodia() As CountryData
            Dim country As New CountryData( _
             "Cambodia", "CB", "KH", "KHM", "116", "kh", _
             smCambodiaCountryCodes, _
             smCambodiaIdds, _
             smCambodiaNdds)
            Return country
        End Function

        Private Shared ReadOnly smCameroon As CountryData = InitializeCameroon()
        Private Shared ReadOnly smCameroonCountryCodes As String() = {"+237"}
        Private Shared ReadOnly smCameroonIdds As String() = {"00"}
        Private Shared ReadOnly smCameroonNdds As String() = {}
        Private Shared Function InitializeCameroon() As CountryData
            Dim country As New CountryData( _
             "Cameroon", "CM", "CM", "CMR", "120", "cm", _
             smCameroonCountryCodes, _
             smCameroonIdds, _
             smCameroonNdds)
            Return country
        End Function

        Private Shared ReadOnly smCanada As CountryData = InitializeCanada()
        Private Shared ReadOnly smCanadaCountryCodes As String() = {"+1"}
        Private Shared ReadOnly smCanadaIdds As String() = {"011"}
        Private Shared ReadOnly smCanadaNdds As String() = {"1"}
        Private Shared Function InitializeCanada() As CountryData
            Dim country As New CountryData( _
             "Canada", "CA", "CA", "CAN", "124", "ca", _
             smCanadaCountryCodes, _
             smCanadaIdds, _
             smCanadaNdds)
            Return country
        End Function

        Private Shared ReadOnly smCapeVerde As CountryData = InitializeCapeVerde()
        Private Shared ReadOnly smCapeVerdeCountryCodes As String() = {"+238"}
        Private Shared ReadOnly smCapeVerdeIdds As String() = {"0"}
        Private Shared ReadOnly smCapeVerdeNdds As String() = {}
        Private Shared Function InitializeCapeVerde() As CountryData
            Dim country As New CountryData( _
             "CapeVerde", "CV", "CV", "CPV", "132", "cv", _
             smCapeVerdeCountryCodes, _
             smCapeVerdeIdds, _
             smCapeVerdeNdds)
            Return country
        End Function

        Private Shared ReadOnly smCaymanIslands As CountryData = InitializeCaymanIslands()
        Private Shared ReadOnly smCaymanIslandsCountryCodes As String() = {"+1-345"}
        Private Shared ReadOnly smCaymanIslandsIdds As String() = {"011"}
        Private Shared ReadOnly smCaymanIslandsNdds As String() = {"1"}
        Private Shared Function InitializeCaymanIslands() As CountryData
            Dim country As New CountryData( _
             "CaymanIslands", "CJ", "KY", "CYM", "136", "ky", _
             smCaymanIslandsCountryCodes, _
             smCaymanIslandsIdds, _
             smCaymanIslandsNdds)
            Return country
        End Function

        Private Shared ReadOnly smCentralAfricanRepublic As CountryData = InitializeCentralAfricanRepublic()
        Private Shared ReadOnly smCentralAfricanRepublicCountryCodes As String() = {"+236"}
        Private Shared ReadOnly smCentralAfricanRepublicIdds As String() = {"00"}
        Private Shared ReadOnly smCentralAfricanRepublicNdds As String() = {}
        Private Shared Function InitializeCentralAfricanRepublic() As CountryData
            Dim country As New CountryData( _
             "CentralAfricanRepublic", "CT", "CF", "CAF", "140", "cf", _
             smCentralAfricanRepublicCountryCodes, _
             smCentralAfricanRepublicIdds, _
             smCentralAfricanRepublicNdds)
            Return country
        End Function

        Private Shared ReadOnly smChad As CountryData = InitializeChad()
        Private Shared ReadOnly smChadCountryCodes As String() = {"+235"}
        Private Shared ReadOnly smChadIdds As String() = {"15"}
        Private Shared ReadOnly smChadNdds As String() = {}
        Private Shared Function InitializeChad() As CountryData
            Dim country As New CountryData( _
             "Chad", "CD", "TD", "TCD", "148", "td", _
             smChadCountryCodes, _
             smChadIdds, _
             smChadNdds)
            Return country
        End Function

        Private Shared ReadOnly smChile As CountryData = InitializeChile()
        Private Shared ReadOnly smChileCountryCodes As String() = {"+56"}
        Private Shared ReadOnly smChileIdds As String() = {"00"}
        Private Shared ReadOnly smChileNdds As String() = {"0"}
        Private Shared Function InitializeChile() As CountryData
            Dim country As New CountryData( _
             "Chile", "CI", "CL", "CHL", "152", "cl", _
             smChileCountryCodes, _
             smChileIdds, _
             smChileNdds)
            Return country
        End Function

        Private Shared ReadOnly smChina As CountryData = InitializeChina()
        Private Shared ReadOnly smChinaCountryCodes As String() = {"+86"}
        Private Shared ReadOnly smChinaIdds As String() = {"00"}
        Private Shared ReadOnly smChinaNdds As String() = {"0"}
        Private Shared Function InitializeChina() As CountryData
            Dim country As New CountryData( _
             "China", "CH", "CN", "CHN", "156", "cn", _
             smChinaCountryCodes, _
             smChinaIdds, _
             smChinaNdds)
            Return country
        End Function

        Private Shared ReadOnly smChristmasIsland As CountryData = InitializeChristmasIsland()
        Private Shared ReadOnly smChristmasIslandCountryCodes As String() = {"+61-8"}
        Private Shared ReadOnly smChristmasIslandIdds As String() = {"0011"}
        Private Shared ReadOnly smChristmasIslandNdds As String() = {"0"}
        Private Shared Function InitializeChristmasIsland() As CountryData
            Dim country As New CountryData( _
             "ChristmasIsland", "KT", "CX", "CXR", "162", "cx", _
             smChristmasIslandCountryCodes, _
             smChristmasIslandIdds, _
             smChristmasIslandNdds)
            Return country
        End Function

        Private Shared ReadOnly smCocosKeelingIslands As CountryData = InitializeCocosKeelingIslands()
        Private Shared ReadOnly smCocosKeelingIslandsCountryCodes As String() = {""}
        Private Shared ReadOnly smCocosKeelingIslandsIdds As String() = {""}
        Private Shared ReadOnly smCocosKeelingIslandsNdds As String() = {""}
        Private Shared Function InitializeCocosKeelingIslands() As CountryData
            Dim country As New CountryData( _
             "CocosKeelingIslands", "CK", "CC", "CCK", "166", "cc", _
             smCocosKeelingIslandsCountryCodes, _
             smCocosKeelingIslandsIdds, _
             smCocosKeelingIslandsNdds)
            Return country
        End Function

        Private Shared ReadOnly smColombia As CountryData = InitializeColombia()
        Private Shared ReadOnly smColombiaCountryCodes As String() = {"+57"}
        Private Shared ReadOnly smColombiaIdds As String() = {"005", "007", "009", "#555", "#999"}
        Private Shared ReadOnly smColombiaNdds As String() = {"03", "05", "07", "09"}
        Private Shared Function InitializeColombia() As CountryData
            Dim country As New CountryData( _
             "Colombia", "CO", "CO", "COL", "170", "co", _
             smColombiaCountryCodes, _
             smColombiaIdds, _
             smColombiaNdds)
            Return country
        End Function

        Private Shared ReadOnly smComoros As CountryData = InitializeComoros()
        Private Shared ReadOnly smComorosCountryCodes As String() = {"+269"}
        Private Shared ReadOnly smComorosIdds As String() = {"00"}
        Private Shared ReadOnly smComorosNdds As String() = {}
        Private Shared Function InitializeComoros() As CountryData
            Dim country As New CountryData( _
             "Comoros", "CN", "KM", "COM", "174", "km", _
             smComorosCountryCodes, _
             smComorosIdds, _
             smComorosNdds)
            Return country
        End Function

        Private Shared ReadOnly smCongoDemocraticRepublic As CountryData = InitializeCongoDemocraticRepublic()
        Private Shared ReadOnly smCongoDemocraticRepublicCountryCodes As String() = {"+243"}
        Private Shared ReadOnly smCongoDemocraticRepublicIdds As String() = {"00"}
        Private Shared ReadOnly smCongoDemocraticRepublicNdds As String() = {}
        Private Shared Function InitializeCongoDemocraticRepublic() As CountryData
            Dim country As New CountryData( _
             "CongoDemocraticRepublic", "CG", "CD", "COD", "180", "cd", _
             smCongoDemocraticRepublicCountryCodes, _
             smCongoDemocraticRepublicIdds, _
             smCongoDemocraticRepublicNdds)
            Return country
        End Function

        Private Shared ReadOnly smCongoRepublic As CountryData = InitializeCongoRepublic()
        Private Shared ReadOnly smCongoRepublicCountryCodes As String() = {"+242"}
        Private Shared ReadOnly smCongoRepublicIdds As String() = {"00"}
        Private Shared ReadOnly smCongoRepublicNdds As String() = {}
        Private Shared Function InitializeCongoRepublic() As CountryData
            Dim country As New CountryData( _
             "CongoRepublic", "CF", "CG", "COG", "178", "cg", _
             smCongoRepublicCountryCodes, _
             smCongoRepublicIdds, _
             smCongoRepublicNdds)
            Return country
        End Function

        Private Shared ReadOnly smCookIslands As CountryData = InitializeCookIslands()
        Private Shared ReadOnly smCookIslandsCountryCodes As String() = {"+682"}
        Private Shared ReadOnly smCookIslandsIdds As String() = {"00"}
        Private Shared ReadOnly smCookIslandsNdds As String() = {"00"}
        Private Shared Function InitializeCookIslands() As CountryData
            Dim country As New CountryData( _
             "CookIslands", "CW", "CK", "COK", "184", "ck", _
             smCookIslandsCountryCodes, _
             smCookIslandsIdds, _
             smCookIslandsNdds)
            Return country
        End Function

        Private Shared ReadOnly smCostaRica As CountryData = InitializeCostaRica()
        Private Shared ReadOnly smCostaRicaCountryCodes As String() = {"+506"}
        Private Shared ReadOnly smCostaRicaIdds As String() = {"00"}
        Private Shared ReadOnly smCostaRicaNdds As String() = {}
        Private Shared Function InitializeCostaRica() As CountryData
            Dim country As New CountryData( _
             "CostaRica", "CS", "CR", "CRI", "188", "cr", _
             smCostaRicaCountryCodes, _
             smCostaRicaIdds, _
             smCostaRicaNdds)
            Return country
        End Function

        Private Shared ReadOnly smCoteDIvoire As CountryData = InitializeCoteDIvoire()
        Private Shared ReadOnly smCoteDIvoireCountryCodes As String() = {"+225"}
        Private Shared ReadOnly smCoteDIvoireIdds As String() = {"00"}
        Private Shared ReadOnly smCoteDIvoireNdds As String() = {"0"}
        Private Shared Function InitializeCoteDIvoire() As CountryData
            Dim country As New CountryData( _
             "CoteDIvoire", "IV", "CI", "CIV", "384", "ci", _
             smCoteDIvoireCountryCodes, _
             smCoteDIvoireIdds, _
             smCoteDIvoireNdds)
            Return country
        End Function

        Private Shared ReadOnly smCroatia As CountryData = InitializeCroatia()
        Private Shared ReadOnly smCroatiaCountryCodes As String() = {"+385"}
        Private Shared ReadOnly smCroatiaIdds As String() = {"00"}
        Private Shared ReadOnly smCroatiaNdds As String() = {"0"}
        Private Shared Function InitializeCroatia() As CountryData
            Dim country As New CountryData( _
             "Croatia", "HR", "HR", "HRV", "191", "hr", _
             smCroatiaCountryCodes, _
             smCroatiaIdds, _
             smCroatiaNdds)
            Return country
        End Function

        Private Shared ReadOnly smCuba As CountryData = InitializeCuba()
        Private Shared ReadOnly smCubaCountryCodes As String() = {"+53"}
        Private Shared ReadOnly smCubaIdds As String() = {"119"}
        Private Shared ReadOnly smCubaNdds As String() = {"0"}
        Private Shared Function InitializeCuba() As CountryData
            Dim country As New CountryData( _
             "Cuba", "CU", "CU", "CUB", "192", "cu", _
             smCubaCountryCodes, _
             smCubaIdds, _
             smCubaNdds)
            Return country
        End Function

        Private Shared ReadOnly smCyprus As CountryData = InitializeCyprus()
        Private Shared ReadOnly smCyprusCountryCodes As String() = {"+357"}
        Private Shared ReadOnly smCyprusIdds As String() = {"00"}
        Private Shared ReadOnly smCyprusNdds As String() = {}
        Private Shared Function InitializeCyprus() As CountryData
            Dim country As New CountryData( _
             "Cyprus", "CY", "CY", "CYP", "196", "cy", _
             smCyprusCountryCodes, _
             smCyprusIdds, _
             smCyprusNdds)
            Return country
        End Function

        Private Shared ReadOnly smCzechRepublic As CountryData = InitializeCzechRepublic()
        Private Shared ReadOnly smCzechRepublicCountryCodes As String() = {"+420"}
        Private Shared ReadOnly smCzechRepublicIdds As String() = {"000", "95200"}
        Private Shared ReadOnly smCzechRepublicNdds As String() = {}
        Private Shared Function InitializeCzechRepublic() As CountryData
            Dim country As New CountryData( _
             "CzechRepublic", "EZ", "CZ", "CZE", "203", "cz", _
             smCzechRepublicCountryCodes, _
             smCzechRepublicIdds, _
             smCzechRepublicNdds)
            Return country
        End Function

        Private Shared ReadOnly smDenmark As CountryData = InitializeDenmark()
        Private Shared ReadOnly smDenmarkCountryCodes As String() = {"+45"}
        Private Shared ReadOnly smDenmarkIdds As String() = {"00"}
        Private Shared ReadOnly smDenmarkNdds As String() = {}
        Private Shared Function InitializeDenmark() As CountryData
            Dim country As New CountryData( _
             "Denmark", "DA", "DK", "DNK", "208", "dk", _
             smDenmarkCountryCodes, _
             smDenmarkIdds, _
             smDenmarkNdds)
            Return country
        End Function

        Private Shared ReadOnly smDjibouti As CountryData = InitializeDjibouti()
        Private Shared ReadOnly smDjiboutiCountryCodes As String() = {"+253"}
        Private Shared ReadOnly smDjiboutiIdds As String() = {"00"}
        Private Shared ReadOnly smDjiboutiNdds As String() = {}
        Private Shared Function InitializeDjibouti() As CountryData
            Dim country As New CountryData( _
             "Djibouti", "DJ", "DJ", "DJI", "262", "dj", _
             smDjiboutiCountryCodes, _
             smDjiboutiIdds, _
             smDjiboutiNdds)
            Return country
        End Function

        Private Shared ReadOnly smDominica As CountryData = InitializeDominica()
        Private Shared ReadOnly smDominicaCountryCodes As String() = {"+1-767"}
        Private Shared ReadOnly smDominicaIdds As String() = {"011"}
        Private Shared ReadOnly smDominicaNdds As String() = {"1"}
        Private Shared Function InitializeDominica() As CountryData
            Dim country As New CountryData( _
             "Dominica", "DO", "DM", "DMA", "212", "dm", _
             smDominicaCountryCodes, _
             smDominicaIdds, _
             smDominicaNdds)
            Return country
        End Function

        Private Shared ReadOnly smDominicanRepublic As CountryData = InitializeDominicanRepublic()
        Private Shared ReadOnly smDominicanRepublicCountryCodes As String() = {"+1-809"}
        Private Shared ReadOnly smDominicanRepublicIdds As String() = {"011"}
        Private Shared ReadOnly smDominicanRepublicNdds As String() = {"1"}
        Private Shared Function InitializeDominicanRepublic() As CountryData
            Dim country As New CountryData( _
             "DominicanRepublic", "DR", "DO", "DOM", "214", "do", _
             smDominicanRepublicCountryCodes, _
             smDominicanRepublicIdds, _
             smDominicanRepublicNdds)
            Return country
        End Function

        Private Shared ReadOnly smEastTimor As CountryData = InitializeEastTimor()
        Private Shared ReadOnly smEastTimorCountryCodes As String() = {"+670"}
        Private Shared ReadOnly smEastTimorIdds As String() = {"00"}
        Private Shared ReadOnly smEastTimorNdds As String() = {}
        Private Shared Function InitializeEastTimor() As CountryData
            Dim country As New CountryData( _
             "EastTimor", "TT", "TL", "TLS", "626", "tl", _
             smEastTimorCountryCodes, _
             smEastTimorIdds, _
             smEastTimorNdds)
            Return country
        End Function

        Private Shared ReadOnly smEcuador As CountryData = InitializeEcuador()
        Private Shared ReadOnly smEcuadorCountryCodes As String() = {"+593"}
        Private Shared ReadOnly smEcuadorIdds As String() = {"00"}
        Private Shared ReadOnly smEcuadorNdds As String() = {"0"}
        Private Shared Function InitializeEcuador() As CountryData
            Dim country As New CountryData( _
             "Ecuador", "EC", "EC", "ECU", "218", "ec", _
             smEcuadorCountryCodes, _
             smEcuadorIdds, _
             smEcuadorNdds)
            Return country
        End Function

        Private Shared ReadOnly smEgypt As CountryData = InitializeEgypt()
        Private Shared ReadOnly smEgyptCountryCodes As String() = {"+20"}
        Private Shared ReadOnly smEgyptIdds As String() = {"00"}
        Private Shared ReadOnly smEgyptNdds As String() = {"0"}
        Private Shared Function InitializeEgypt() As CountryData
            Dim country As New CountryData( _
             "Egypt", "EG", "EG", "EGY", "818", "eg", _
             smEgyptCountryCodes, _
             smEgyptIdds, _
             smEgyptNdds)
            Return country
        End Function

        Private Shared ReadOnly smElSalvador As CountryData = InitializeElSalvador()
        Private Shared ReadOnly smElSalvadorCountryCodes As String() = {"+503"}
        Private Shared ReadOnly smElSalvadorIdds As String() = {"00", "144+00"}
        Private Shared ReadOnly smElSalvadorNdds As String() = {}
        Private Shared Function InitializeElSalvador() As CountryData
            Dim country As New CountryData( _
             "ElSalvador", "ES", "SV", "SLV", "222", "sv", _
             smElSalvadorCountryCodes, _
             smElSalvadorIdds, _
             smElSalvadorNdds)
            Return country
        End Function

        Private Shared ReadOnly smEquatorialGuinea As CountryData = InitializeEquatorialGuinea()
        Private Shared ReadOnly smEquatorialGuineaCountryCodes As String() = {"+240"}
        Private Shared ReadOnly smEquatorialGuineaIdds As String() = {"00"}
        Private Shared ReadOnly smEquatorialGuineaNdds As String() = {}
        Private Shared Function InitializeEquatorialGuinea() As CountryData
            Dim country As New CountryData( _
             "EquatorialGuinea", "EK", "GQ", "GNQ", "226", "gq", _
             smEquatorialGuineaCountryCodes, _
             smEquatorialGuineaIdds, _
             smEquatorialGuineaNdds)
            Return country
        End Function

        Private Shared ReadOnly smEritrea As CountryData = InitializeEritrea()
        Private Shared ReadOnly smEritreaCountryCodes As String() = {"+291"}
        Private Shared ReadOnly smEritreaIdds As String() = {"00"}
        Private Shared ReadOnly smEritreaNdds As String() = {"0"}
        Private Shared Function InitializeEritrea() As CountryData
            Dim country As New CountryData( _
             "Eritrea", "ER", "ER", "ERI", "232", "er", _
             smEritreaCountryCodes, _
             smEritreaIdds, _
             smEritreaNdds)
            Return country
        End Function

        Private Shared ReadOnly smEstonia As CountryData = InitializeEstonia()
        Private Shared ReadOnly smEstoniaCountryCodes As String() = {"+372"}
        Private Shared ReadOnly smEstoniaIdds As String() = {"00"}
        Private Shared ReadOnly smEstoniaNdds As String() = {"0"}
        Private Shared Function InitializeEstonia() As CountryData
            Dim country As New CountryData( _
             "Estonia", "EN", "EE", "EST", "233", "ee", _
             smEstoniaCountryCodes, _
             smEstoniaIdds, _
             smEstoniaNdds)
            Return country
        End Function

        Private Shared ReadOnly smEthiopia As CountryData = InitializeEthiopia()
        Private Shared ReadOnly smEthiopiaCountryCodes As String() = {"+251"}
        Private Shared ReadOnly smEthiopiaIdds As String() = {"00"}
        Private Shared ReadOnly smEthiopiaNdds As String() = {}
        Private Shared Function InitializeEthiopia() As CountryData
            Dim country As New CountryData( _
             "Ethiopia", "ET", "ET", "ETH", "231", "et", _
             smEthiopiaCountryCodes, _
             smEthiopiaIdds, _
             smEthiopiaNdds)
            Return country
        End Function

        Private Shared ReadOnly smFalklandIslandsIslasMalvinas As CountryData = InitializeFalklandIslandsIslasMalvinas()
        Private Shared ReadOnly smFalklandIslandsIslasMalvinasCountryCodes As String() = {"+500"}
        Private Shared ReadOnly smFalklandIslandsIslasMalvinasIdds As String() = {"00"}
        Private Shared ReadOnly smFalklandIslandsIslasMalvinasNdds As String() = {}
        Private Shared Function InitializeFalklandIslandsIslasMalvinas() As CountryData
            Dim country As New CountryData( _
             "FalklandIslandsIslasMalvinas", "FK", "FK", "FLK", "238", "fk", _
             smFalklandIslandsIslasMalvinasCountryCodes, _
             smFalklandIslandsIslasMalvinasIdds, _
             smFalklandIslandsIslasMalvinasNdds)
            Return country
        End Function

        Private Shared ReadOnly smFaroeIslands As CountryData = InitializeFaroeIslands()
        Private Shared ReadOnly smFaroeIslandsCountryCodes As String() = {"+298"}
        Private Shared ReadOnly smFaroeIslandsIdds As String() = {"00"}
        Private Shared ReadOnly smFaroeIslandsNdds As String() = {}
        Private Shared Function InitializeFaroeIslands() As CountryData
            Dim country As New CountryData( _
             "FaroeIslands", "FO", "FO", "FRO", "234", "fo", _
             smFaroeIslandsCountryCodes, _
             smFaroeIslandsIdds, _
             smFaroeIslandsNdds)
            Return country
        End Function

        Private Shared ReadOnly smFiji As CountryData = InitializeFiji()
        Private Shared ReadOnly smFijiCountryCodes As String() = {"+679"}
        Private Shared ReadOnly smFijiIdds As String() = {"00"}
        Private Shared ReadOnly smFijiNdds As String() = {}
        Private Shared Function InitializeFiji() As CountryData
            Dim country As New CountryData( _
             "Fiji", "FJ", "FJ", "FJI", "242", "fj", _
             smFijiCountryCodes, _
             smFijiIdds, _
             smFijiNdds)
            Return country
        End Function

        Private Shared ReadOnly smFinland As CountryData = InitializeFinland()
        Private Shared ReadOnly smFinlandCountryCodes As String() = {"+358"}
        Private Shared ReadOnly smFinlandIdds As String() = {"00", "990", "994", "999"}
        Private Shared ReadOnly smFinlandNdds As String() = {"0"}
        Private Shared Function InitializeFinland() As CountryData
            Dim country As New CountryData( _
             "Finland", "FI", "FI", "FIN", "246", "fi", _
             smFinlandCountryCodes, _
             smFinlandIdds, _
             smFinlandNdds)
            Return country
        End Function

        Private Shared ReadOnly smFrance As CountryData = InitializeFrance()
        Private Shared ReadOnly smFranceCountryCodes As String() = {"+33"}
        Private Shared ReadOnly smFranceIdds As String() = {"00", "40", "50", "70", "90"}
        Private Shared ReadOnly smFranceNdds As String() = {"0"}
        Private Shared Function InitializeFrance() As CountryData
            Dim country As New CountryData( _
             "France", "FR", "FR", "FRA", "250", "fr", _
             smFranceCountryCodes, _
             smFranceIdds, _
             smFranceNdds)
            Return country
        End Function

        Private Shared ReadOnly smFrenchGuiana As CountryData = InitializeFrenchGuiana()
        Private Shared ReadOnly smFrenchGuianaCountryCodes As String() = {"+594"}
        Private Shared ReadOnly smFrenchGuianaIdds As String() = {"00"}
        Private Shared ReadOnly smFrenchGuianaNdds As String() = {}
        Private Shared Function InitializeFrenchGuiana() As CountryData
            Dim country As New CountryData( _
             "FrenchGuiana", "FG", "GF", "GUF", "254", "gf", _
             smFrenchGuianaCountryCodes, _
             smFrenchGuianaIdds, _
             smFrenchGuianaNdds)
            Return country
        End Function

        Private Shared ReadOnly smFrenchPolynesia As CountryData = InitializeFrenchPolynesia()
        Private Shared ReadOnly smFrenchPolynesiaCountryCodes As String() = {"+689"}
        Private Shared ReadOnly smFrenchPolynesiaIdds As String() = {"00"}
        Private Shared ReadOnly smFrenchPolynesiaNdds As String() = {}
        Private Shared Function InitializeFrenchPolynesia() As CountryData
            Dim country As New CountryData( _
             "FrenchPolynesia", "FP", "PF", "PYF", "258", "pf", _
             smFrenchPolynesiaCountryCodes, _
             smFrenchPolynesiaIdds, _
             smFrenchPolynesiaNdds)
            Return country
        End Function

        Private Shared ReadOnly smFrenchSouthernAntarcticLands As CountryData = InitializeFrenchSouthernAntarcticLands()
        Private Shared ReadOnly smFrenchSouthernAntarcticLandsCountryCodes As String() = {}
        Private Shared ReadOnly smFrenchSouthernAntarcticLandsIdds As String() = {}
        Private Shared ReadOnly smFrenchSouthernAntarcticLandsNdds As String() = {}
        Private Shared Function InitializeFrenchSouthernAntarcticLands() As CountryData
            Dim country As New CountryData( _
             "FrenchSouthernAntarcticLands", "FS", "TF", "ATF", "260", "tf", _
             smFrenchSouthernAntarcticLandsCountryCodes, _
             smFrenchSouthernAntarcticLandsIdds, _
             smFrenchSouthernAntarcticLandsNdds)
            Return country
        End Function

        Private Shared ReadOnly smGabon As CountryData = InitializeGabon()
        Private Shared ReadOnly smGabonCountryCodes As String() = {}
        Private Shared ReadOnly smGabonIdds As String() = {}
        Private Shared ReadOnly smGabonNdds As String() = {}
        Private Shared Function InitializeGabon() As CountryData
            Dim country As New CountryData( _
             "Gabon", "GB", "GA", "GAB", "266", "ga", _
             smGabonCountryCodes, _
             smGabonIdds, _
             smGabonNdds)
            Return country
        End Function

        Private Shared ReadOnly smGambia As CountryData = InitializeGambia()
        Private Shared ReadOnly smGambiaCountryCodes As String() = {"+220"}
        Private Shared ReadOnly smGambiaIdds As String() = {"00"}
        Private Shared ReadOnly smGambiaNdds As String() = {}
        Private Shared Function InitializeGambia() As CountryData
            Dim country As New CountryData( _
             "Gambia", "GA", "GM", "GMB", "270", "gm", _
             smGambiaCountryCodes, _
             smGambiaIdds, _
             smGambiaNdds)
            Return country
        End Function

        Private Shared ReadOnly smGazaStrip As CountryData = InitializeGazaStrip()
        Private Shared ReadOnly smGazaStripCountryCodes As String() = {}
        Private Shared ReadOnly smGazaStripIdds As String() = {}
        Private Shared ReadOnly smGazaStripNdds As String() = {}
        Private Shared Function InitializeGazaStrip() As CountryData
            Dim country As New CountryData( _
             "GazaStrip", "GZ", "PS", "PSE", "275", "ps", _
             smGazaStripCountryCodes, _
             smGazaStripIdds, _
             smGazaStripNdds)
            Return country
        End Function

        Private Shared ReadOnly smGeorgia As CountryData = InitializeGeorgia()
        Private Shared ReadOnly smGeorgiaCountryCodes As String() = {"+995"}
        Private Shared ReadOnly smGeorgiaIdds As String() = {"8~10"}
        Private Shared ReadOnly smGeorgiaNdds As String() = {"8"}
        Private Shared Function InitializeGeorgia() As CountryData
            Dim country As New CountryData( _
             "Georgia", "GG", "GE", "GEO", "268", "ge", _
             smGeorgiaCountryCodes, _
             smGeorgiaIdds, _
             smGeorgiaNdds)
            Return country
        End Function

        Private Shared ReadOnly smGermany As CountryData = InitializeGermany()
        Private Shared ReadOnly smGermanyCountryCodes As String() = {"+49"}
        Private Shared ReadOnly smGermanyIdds As String() = {"00"}
        Private Shared ReadOnly smGermanyNdds As String() = {}
        Private Shared Function InitializeGermany() As CountryData
            Dim country As New CountryData( _
             "Germany", "GM", "DE", "DEU", "276", "de", _
             smGermanyCountryCodes, _
             smGermanyIdds, _
             smGermanyNdds)
            Return country
        End Function

        Private Shared ReadOnly smGhana As CountryData = InitializeGhana()
        Private Shared ReadOnly smGhanaCountryCodes As String() = {"+233"}
        Private Shared ReadOnly smGhanaIdds As String() = {"00"}
        Private Shared ReadOnly smGhanaNdds As String() = {}
        Private Shared Function InitializeGhana() As CountryData
            Dim country As New CountryData( _
             "Ghana", "GH", "GH", "GHA", "288", "gh", _
             smGhanaCountryCodes, _
             smGhanaIdds, _
             smGhanaNdds)
            Return country
        End Function

        Private Shared ReadOnly smGibraltar As CountryData = InitializeGibraltar()
        Private Shared ReadOnly smGibraltarCountryCodes As String() = {"+350"}
        Private Shared ReadOnly smGibraltarIdds As String() = {"00"}
        Private Shared ReadOnly smGibraltarNdds As String() = {}
        Private Shared Function InitializeGibraltar() As CountryData
            Dim country As New CountryData( _
             "Gibraltar", "GI", "GI", "GIB", "292", "gi", _
             smGibraltarCountryCodes, _
             smGibraltarIdds, _
             smGibraltarNdds)
            Return country
        End Function

        Private Shared ReadOnly smGreece As CountryData = InitializeGreece()
        Private Shared ReadOnly smGreeceCountryCodes As String() = {"+30"}
        Private Shared ReadOnly smGreeceIdds As String() = {"00"}
        Private Shared ReadOnly smGreeceNdds As String() = {}
        Private Shared Function InitializeGreece() As CountryData
            Dim country As New CountryData( _
             "Greece", "GR", "GR", "GRC", "300", "gr", _
             smGreeceCountryCodes, _
             smGreeceIdds, _
             smGreeceNdds)
            Return country
        End Function

        Private Shared ReadOnly smGreenland As CountryData = InitializeGreenland()
        Private Shared ReadOnly smGreenlandCountryCodes As String() = {"+299"}
        Private Shared ReadOnly smGreenlandIdds As String() = {"00"}
        Private Shared ReadOnly smGreenlandNdds As String() = {}
        Private Shared Function InitializeGreenland() As CountryData
            Dim country As New CountryData( _
             "Greenland", "GL", "GL", "GRL", "304", "gl", _
             smGreenlandCountryCodes, _
             smGreenlandIdds, _
             smGreenlandNdds)
            Return country
        End Function

        Private Shared ReadOnly smGrenada As CountryData = InitializeGrenada()
        Private Shared ReadOnly smGrenadaCountryCodes As String() = {"+1-473"}
        Private Shared ReadOnly smGrenadaIdds As String() = {"011"}
        Private Shared ReadOnly smGrenadaNdds As String() = {"1"}
        Private Shared Function InitializeGrenada() As CountryData
            Dim country As New CountryData( _
             "Grenada", "GJ", "GD", "GRD", "308", "gd", _
             smGrenadaCountryCodes, _
             smGrenadaIdds, _
             smGrenadaNdds)
            Return country
        End Function

        Private Shared ReadOnly smGuadeloupe As CountryData = InitializeGuadeloupe()
        Private Shared ReadOnly smGuadeloupeCountryCodes As String() = {"+590"}
        Private Shared ReadOnly smGuadeloupeIdds As String() = {"00"}
        Private Shared ReadOnly smGuadeloupeNdds As String() = {}
        Private Shared Function InitializeGuadeloupe() As CountryData
            Dim country As New CountryData( _
             "Guadeloupe", "GP", "GP", "GLP", "312", "gp", _
             smGuadeloupeCountryCodes, _
             smGuadeloupeIdds, _
             smGuadeloupeNdds)
            Return country
        End Function

        Private Shared ReadOnly smGuam As CountryData = InitializeGuam()
        Private Shared ReadOnly smGuamCountryCodes As String() = {"+1-671"}
        Private Shared ReadOnly smGuamIdds As String() = {"011"}
        Private Shared ReadOnly smGuamNdds As String() = {"1"}
        Private Shared Function InitializeGuam() As CountryData
            Dim country As New CountryData( _
             "Guam", "GQ", "GU", "GUM", "316", "gu", _
             smGuamCountryCodes, _
             smGuamIdds, _
             smGuamNdds)
            Return country
        End Function

        Private Shared ReadOnly smGuatemala As CountryData = InitializeGuatemala()
        Private Shared ReadOnly smGuatemalaCountryCodes As String() = {"+502"}
        Private Shared ReadOnly smGuatemalaIdds As String() = {"00", "130+00", "147-00"}
        Private Shared ReadOnly smGuatemalaNdds As String() = {}
        Private Shared Function InitializeGuatemala() As CountryData
            Dim country As New CountryData( _
             "Guatemala", "GT", "GT", "GTM", "320", "gt", _
             smGuatemalaCountryCodes, _
             smGuatemalaIdds, _
             smGuatemalaNdds)
            Return country
        End Function

        Private Shared ReadOnly smGuinea As CountryData = InitializeGuinea()
        Private Shared ReadOnly smGuineaCountryCodes As String() = {"+224"}
        Private Shared ReadOnly smGuineaIdds As String() = {"00"}
        Private Shared ReadOnly smGuineaNdds As String() = {"0"}
        Private Shared Function InitializeGuinea() As CountryData
            Dim country As New CountryData( _
             "Guinea", "GV", "GN", "GIN", "324", "gn", _
             smGuineaCountryCodes, _
             smGuineaIdds, _
             smGuineaNdds)
            Return country
        End Function

        Private Shared ReadOnly smGuineaBissau As CountryData = InitializeGuineaBissau()
        Private Shared ReadOnly smGuineaBissauCountryCodes As String() = {"+245"}
        Private Shared ReadOnly smGuineaBissauIdds As String() = {"00"}
        Private Shared ReadOnly smGuineaBissauNdds As String() = {}
        Private Shared Function InitializeGuineaBissau() As CountryData
            Dim country As New CountryData( _
             "GuineaBissau", "PU", "GW", "GNB", "624", "gw", _
             smGuineaBissauCountryCodes, _
             smGuineaBissauIdds, _
             smGuineaBissauNdds)
            Return country
        End Function

        Private Shared ReadOnly smGuyana As CountryData = InitializeGuyana()
        Private Shared ReadOnly smGuyanaCountryCodes As String() = {"+592"}
        Private Shared ReadOnly smGuyanaIdds As String() = {"001"}
        Private Shared ReadOnly smGuyanaNdds As String() = {"0"}
        Private Shared Function InitializeGuyana() As CountryData
            Dim country As New CountryData( _
             "Guyana", "GY", "GY", "GUY", "328", "gy", _
             smGuyanaCountryCodes, _
             smGuyanaIdds, _
             smGuyanaNdds)
            Return country
        End Function

        Private Shared ReadOnly smHaiti As CountryData = InitializeHaiti()
        Private Shared ReadOnly smHaitiCountryCodes As String() = {"+509"}
        Private Shared ReadOnly smHaitiIdds As String() = {"00"}
        Private Shared ReadOnly smHaitiNdds As String() = {"0"}
        Private Shared Function InitializeHaiti() As CountryData
            Dim country As New CountryData( _
             "Haiti", "HA", "HT", "HTI", "332", "ht", _
             smHaitiCountryCodes, _
             smHaitiIdds, _
             smHaitiNdds)
            Return country
        End Function

        Private Shared ReadOnly smHeardIslandMcDonaldIslands As CountryData = InitializeHeardIslandMcDonaldIslands()
        Private Shared ReadOnly smHeardIslandMcDonaldIslandsCountryCodes As String() = {}
        Private Shared ReadOnly smHeardIslandMcDonaldIslandsIdds As String() = {}
        Private Shared ReadOnly smHeardIslandMcDonaldIslandsNdds As String() = {}
        Private Shared Function InitializeHeardIslandMcDonaldIslands() As CountryData
            Dim country As New CountryData( _
             "HeardIslandMcDonaldIslands", "HM", "HM", "HMD", "334", "hm", _
             smHeardIslandMcDonaldIslandsCountryCodes, _
             smHeardIslandMcDonaldIslandsIdds, _
             smHeardIslandMcDonaldIslandsNdds)
            Return country
        End Function

        Private Shared ReadOnly smHolySeeVaticanCity As CountryData = InitializeHolySeeVaticanCity()
        Private Shared ReadOnly smHolySeeVaticanCityCountryCodes As String() = {}
        Private Shared ReadOnly smHolySeeVaticanCityIdds As String() = {}
        Private Shared ReadOnly smHolySeeVaticanCityNdds As String() = {}
        Private Shared Function InitializeHolySeeVaticanCity() As CountryData
            Dim country As New CountryData( _
             "HolySeeVaticanCity", "VT", "VA", "VAT", "336", "va", _
             smHolySeeVaticanCityCountryCodes, _
             smHolySeeVaticanCityIdds, _
             smHolySeeVaticanCityNdds)
            Return country
        End Function

        Private Shared ReadOnly smHonduras As CountryData = InitializeHonduras()
        Private Shared ReadOnly smHondurasCountryCodes As String() = {"+504"}
        Private Shared ReadOnly smHondurasIdds As String() = {"00"}
        Private Shared ReadOnly smHondurasNdds As String() = {"0"}
        Private Shared Function InitializeHonduras() As CountryData
            Dim country As New CountryData( _
             "Honduras", "HO", "HN", "HND", "340", "hn", _
             smHondurasCountryCodes, _
             smHondurasIdds, _
             smHondurasNdds)
            Return country
        End Function

        Private Shared ReadOnly smHongKong As CountryData = InitializeHongKong()
        Private Shared ReadOnly smHongKongCountryCodes As String() = {"+852"}
        Private Shared ReadOnly smHongKongIdds As String() = {"001", "0080", "009"}
        Private Shared ReadOnly smHongKongNdds As String() = {}
        Private Shared Function InitializeHongKong() As CountryData
            Dim country As New CountryData( _
             "HongKong", "HK", "HK", "HKG", "344", "hk", _
             smHongKongCountryCodes, _
             smHongKongIdds, _
             smHongKongNdds)
            Return country
        End Function

        Private Shared ReadOnly smHungary As CountryData = InitializeHungary()
        Private Shared ReadOnly smHungaryCountryCodes As String() = {"+36"}
        Private Shared ReadOnly smHungaryIdds As String() = {"00"}
        Private Shared ReadOnly smHungaryNdds As String() = {"06"}
        Private Shared Function InitializeHungary() As CountryData
            Dim country As New CountryData( _
             "Hungary", "HU", "HU", "HUN", "348", "hu", _
             smHungaryCountryCodes, _
             smHungaryIdds, _
             smHungaryNdds)
            Return country
        End Function

        Private Shared ReadOnly smIceland As CountryData = InitializeIceland()
        Private Shared ReadOnly smIcelandCountryCodes As String() = {"+354"}
        Private Shared ReadOnly smIcelandIdds As String() = {"00"}
        Private Shared ReadOnly smIcelandNdds As String() = {"0"}
        Private Shared Function InitializeIceland() As CountryData
            Dim country As New CountryData( _
             "Iceland", "IC", "IS", "ISL", "352", "is", _
             smIcelandCountryCodes, _
             smIcelandIdds, _
             smIcelandNdds)
            Return country
        End Function

        Private Shared ReadOnly smIndia As CountryData = InitializeIndia()
        Private Shared ReadOnly smIndiaCountryCodes As String() = {"+91"}
        Private Shared ReadOnly smIndiaIdds As String() = {"00"}
        Private Shared ReadOnly smIndiaNdds As String() = {"0"}
        Private Shared Function InitializeIndia() As CountryData
            Dim country As New CountryData( _
             "India", "IN", "IN", "IND", "356", "in", _
             smIndiaCountryCodes, _
             smIndiaIdds, _
             smIndiaNdds)
            Return country
        End Function

        Private Shared ReadOnly smIndonesia As CountryData = InitializeIndonesia()
        Private Shared ReadOnly smIndonesiaCountryCodes As String() = {"+62"}
        Private Shared ReadOnly smIndonesiaIdds As String() = {"001", "008"}
        Private Shared ReadOnly smIndonesiaNdds As String() = {"0"}
        Private Shared Function InitializeIndonesia() As CountryData
            Dim country As New CountryData( _
             "Indonesia", "ID", "ID", "IDN", "360", "id", _
             smIndonesiaCountryCodes, _
             smIndonesiaIdds, _
             smIndonesiaNdds)
            Return country
        End Function

        Private Shared ReadOnly smIran As CountryData = InitializeIran()
        Private Shared ReadOnly smIranCountryCodes As String() = {"+98"}
        Private Shared ReadOnly smIranIdds As String() = {"00"}
        Private Shared ReadOnly smIranNdds As String() = {"0"}
        Private Shared Function InitializeIran() As CountryData
            Dim country As New CountryData( _
             "Iran", "IR", "IR", "IRN", "364", "ir", _
             smIranCountryCodes, _
             smIranIdds, _
             smIranNdds)
            Return country
        End Function

        Private Shared ReadOnly smIraq As CountryData = InitializeIraq()
        Private Shared ReadOnly smIraqCountryCodes As String() = {"+964"}
        Private Shared ReadOnly smIraqIdds As String() = {"00"}
        Private Shared ReadOnly smIraqNdds As String() = {"0"}
        Private Shared Function InitializeIraq() As CountryData
            Dim country As New CountryData( _
             "Iraq", "IZ", "IQ", "IRQ", "368", "iq", _
             smIraqCountryCodes, _
             smIraqIdds, _
             smIraqNdds)
            Return country
        End Function

        Private Shared ReadOnly smIreland As CountryData = InitializeIreland()
        Private Shared ReadOnly smIrelandCountryCodes As String() = {"+353"}
        Private Shared ReadOnly smIrelandIdds As String() = {"00", "048"}
        Private Shared ReadOnly smIrelandNdds As String() = {"0"}
        Private Shared Function InitializeIreland() As CountryData
            Dim country As New CountryData( _
             "Ireland", "EI", "IE", "IRL", "372", "ie", _
             smIrelandCountryCodes, _
             smIrelandIdds, _
             smIrelandNdds)
            Return country
        End Function

        Private Shared ReadOnly smIsrael As CountryData = InitializeIsrael()
        Private Shared ReadOnly smIsraelCountryCodes As String() = {"+972"}
        Private Shared ReadOnly smIsraelIdds As String() = {"00", "012", "013", "014"}
        Private Shared ReadOnly smIsraelNdds As String() = {"0"}
        Private Shared Function InitializeIsrael() As CountryData
            Dim country As New CountryData( _
             "Israel", "IS", "IL", "ISR", "376", "il", _
             smIsraelCountryCodes, _
             smIsraelIdds, _
             smIsraelNdds)
            Return country
        End Function

        Private Shared ReadOnly smItaly As CountryData = InitializeItaly()
        Private Shared ReadOnly smItalyCountryCodes As String() = {"+39"}
        Private Shared ReadOnly smItalyIdds As String() = {"00"}
        Private Shared ReadOnly smItalyNdds As String() = {}
        Private Shared Function InitializeItaly() As CountryData
            Dim country As New CountryData( _
             "Italy", "IT", "IT", "ITA", "380", "it", _
             smItalyCountryCodes, _
             smItalyIdds, _
             smItalyNdds)
            Return country
        End Function

        Private Shared ReadOnly smJamaica As CountryData = InitializeJamaica()
        Private Shared ReadOnly smJamaicaCountryCodes As String() = {"+1-876"}
        Private Shared ReadOnly smJamaicaIdds As String() = {"011"}
        Private Shared ReadOnly smJamaicaNdds As String() = {"1"}
        Private Shared Function InitializeJamaica() As CountryData
            Dim country As New CountryData( _
             "Jamaica", "JM", "JM", "JAM", "388", "jm", _
             smJamaicaCountryCodes, _
             smJamaicaIdds, _
             smJamaicaNdds)
            Return country
        End Function

        Private Shared ReadOnly smJapan As CountryData = InitializeJapan()
        Private Shared ReadOnly smJapanCountryCodes As String() = {"+81"}
        Private Shared ReadOnly smJapanIdds As String() = {"001", "010", "0061", "0041"}
        Private Shared ReadOnly smJapanNdds As String() = {"0"}
        Private Shared Function InitializeJapan() As CountryData
            Dim country As New CountryData( _
             "Japan", "JA", "JP", "JPN", "392", "jp", _
             smJapanCountryCodes, _
             smJapanIdds, _
             smJapanNdds)
            Return country
        End Function

        Private Shared ReadOnly smJordan As CountryData = InitializeJordan()
        Private Shared ReadOnly smJordanCountryCodes As String() = {"+962"}
        Private Shared ReadOnly smJordanIdds As String() = {"00"}
        Private Shared ReadOnly smJordanNdds As String() = {"0"}
        Private Shared Function InitializeJordan() As CountryData
            Dim country As New CountryData( _
             "Jordan", "JO", "JO", "JOR", "400", "jo", _
             smJordanCountryCodes, _
             smJordanIdds, _
             smJordanNdds)
            Return country
        End Function

        Private Shared ReadOnly smKazakhstan As CountryData = InitializeKazakhstan()
        Private Shared ReadOnly smKazakhstanCountryCodes As String() = {"+7"}
        Private Shared ReadOnly smKazakhstanIdds As String() = {"8~10"}
        Private Shared ReadOnly smKazakhstanNdds As String() = {"8"}
        Private Shared Function InitializeKazakhstan() As CountryData
            Dim country As New CountryData( _
             "Kazakhstan", "KZ", "KZ", "KAZ", "398", "kz", _
             smKazakhstanCountryCodes, _
             smKazakhstanIdds, _
             smKazakhstanNdds)
            Return country
        End Function

        Private Shared ReadOnly smKenya As CountryData = InitializeKenya()
        Private Shared ReadOnly smKenyaCountryCodes As String() = {"+254"}
        Private Shared ReadOnly smKenyaIdds As String() = {"000", "006", "007", "0"}
        Private Shared ReadOnly smKenyaNdds As String() = {""}
        Private Shared Function InitializeKenya() As CountryData
            Dim country As New CountryData( _
             "Kenya", "KE", "KE", "KEN", "404", "ke", _
             smKenyaCountryCodes, _
             smKenyaIdds, _
             smKenyaNdds)
            Return country
        End Function

        Private Shared ReadOnly smKiribati As CountryData = InitializeKiribati()
        Private Shared ReadOnly smKiribatiCountryCodes As String() = {"+686"}
        Private Shared ReadOnly smKiribatiIdds As String() = {"00"}
        Private Shared ReadOnly smKiribatiNdds As String() = {"0"}
        Private Shared Function InitializeKiribati() As CountryData
            Dim country As New CountryData( _
             "Kiribati", "KR", "KI", "KIR", "296", "ki", _
             smKiribatiCountryCodes, _
             smKiribatiIdds, _
             smKiribatiNdds)
            Return country
        End Function

        Private Shared ReadOnly smKoreaNorth As CountryData = InitializeKoreaNorth()
        Private Shared ReadOnly smKoreaNorthCountryCodes As String() = {"+850"}
        Private Shared ReadOnly smKoreaNorthIdds As String() = {"00"}
        Private Shared ReadOnly smKoreaNorthNdds As String() = {"0"}
        Private Shared Function InitializeKoreaNorth() As CountryData
            Dim country As New CountryData( _
             "KoreaNorth", "KN", "KP", "PRK", "408", "kp", _
             smKoreaNorthCountryCodes, _
             smKoreaNorthIdds, _
             smKoreaNorthNdds)
            Return country
        End Function

        Private Shared ReadOnly smKoreaSouth As CountryData = InitializeKoreaSouth()
        Private Shared ReadOnly smKoreaSouthCountryCodes As String() = {"+82"}
        Private Shared ReadOnly smKoreaSouthIdds As String() = {"001", "002", "00700"}
        Private Shared ReadOnly smKoreaSouthNdds As String() = {"0", "082"}
        Private Shared Function InitializeKoreaSouth() As CountryData
            Dim country As New CountryData( _
             "KoreaSouth", "KS", "KR", "KOR", "410", "kr", _
             smKoreaSouthCountryCodes, _
             smKoreaSouthIdds, _
             smKoreaSouthNdds)
            Return country
        End Function

        Private Shared ReadOnly smKuwait As CountryData = InitializeKuwait()
        Private Shared ReadOnly smKuwaitCountryCodes As String() = {"+965"}
        Private Shared ReadOnly smKuwaitIdds As String() = {"00"}
        Private Shared ReadOnly smKuwaitNdds As String() = {"0"}
        Private Shared Function InitializeKuwait() As CountryData
            Dim country As New CountryData( _
             "Kuwait", "KU", "KW", "KWT", "414", "kw", _
             smKuwaitCountryCodes, _
             smKuwaitIdds, _
             smKuwaitNdds)
            Return country
        End Function

        Private Shared ReadOnly smKyrgyzstan As CountryData = InitializeKyrgyzstan()
        Private Shared ReadOnly smKyrgyzstanCountryCodes As String() = {"+996"}
        Private Shared ReadOnly smKyrgyzstanIdds As String() = {"00"}
        Private Shared ReadOnly smKyrgyzstanNdds As String() = {"0"}
        Private Shared Function InitializeKyrgyzstan() As CountryData
            Dim country As New CountryData( _
             "Kyrgyzstan", "KG", "KG", "KGZ", "417", "kg", _
             smKyrgyzstanCountryCodes, _
             smKyrgyzstanIdds, _
             smKyrgyzstanNdds)
            Return country
        End Function

        Private Shared ReadOnly smLaos As CountryData = InitializeLaos()
        Private Shared ReadOnly smLaosCountryCodes As String() = {"+856"}
        Private Shared ReadOnly smLaosIdds As String() = {"00"}
        Private Shared ReadOnly smLaosNdds As String() = {"0"}
        Private Shared Function InitializeLaos() As CountryData
            Dim country As New CountryData( _
             "Laos", "LA", "LA", "LAO", "418", "la", _
             smLaosCountryCodes, _
             smLaosIdds, _
             smLaosNdds)
            Return country
        End Function

        Private Shared ReadOnly smLatvia As CountryData = InitializeLatvia()
        Private Shared ReadOnly smLatviaCountryCodes As String() = {"+371"}
        Private Shared ReadOnly smLatviaIdds As String() = {"00"}
        Private Shared ReadOnly smLatviaNdds As String() = {"8"}
        Private Shared Function InitializeLatvia() As CountryData
            Dim country As New CountryData( _
             "Latvia", "LG", "LV", "LVA", "428", "lv", _
             smLatviaCountryCodes, _
             smLatviaIdds, _
             smLatviaNdds)
            Return country
        End Function

        Private Shared ReadOnly smLebanon As CountryData = InitializeLebanon()
        Private Shared ReadOnly smLebanonCountryCodes As String() = {"+961"}
        Private Shared ReadOnly smLebanonIdds As String() = {"00"}
        Private Shared ReadOnly smLebanonNdds As String() = {"0"}
        Private Shared Function InitializeLebanon() As CountryData
            Dim country As New CountryData( _
             "Lebanon", "LE", "LB", "LBN", "422", "lb", _
             smLebanonCountryCodes, _
             smLebanonIdds, _
             smLebanonNdds)
            Return country
        End Function

        Private Shared ReadOnly smLesotho As CountryData = InitializeLesotho()
        Private Shared ReadOnly smLesothoCountryCodes As String() = {"+266"}
        Private Shared ReadOnly smLesothoIdds As String() = {"00"}
        Private Shared ReadOnly smLesothoNdds As String() = {"0"}
        Private Shared Function InitializeLesotho() As CountryData
            Dim country As New CountryData( _
             "Lesotho", "LT", "LS", "LSO", "426", "ls", _
             smLesothoCountryCodes, _
             smLesothoIdds, _
             smLesothoNdds)
            Return country
        End Function

        Private Shared ReadOnly smLiberia As CountryData = InitializeLiberia()
        Private Shared ReadOnly smLiberiaCountryCodes As String() = {"+231"}
        Private Shared ReadOnly smLiberiaIdds As String() = {"00"}
        Private Shared ReadOnly smLiberiaNdds As String() = {"22"}
        Private Shared Function InitializeLiberia() As CountryData
            Dim country As New CountryData( _
             "Liberia", "LI", "LR", "LBR", "430", "lr", _
             smLiberiaCountryCodes, _
             smLiberiaIdds, _
             smLiberiaNdds)
            Return country
        End Function

        Private Shared ReadOnly smLibya As CountryData = InitializeLibya()
        Private Shared ReadOnly smLibyaCountryCodes As String() = {"+218"}
        Private Shared ReadOnly smLibyaIdds As String() = {"00"}
        Private Shared ReadOnly smLibyaNdds As String() = {"0"}
        Private Shared Function InitializeLibya() As CountryData
            Dim country As New CountryData( _
             "Libya", "LY", "LY", "LBY", "434", "ly", _
             smLibyaCountryCodes, _
             smLibyaIdds, _
             smLibyaNdds)
            Return country
        End Function

        Private Shared ReadOnly smLiechtenstein As CountryData = InitializeLiechtenstein()
        Private Shared ReadOnly smLiechtensteinCountryCodes As String() = {"+423"}
        Private Shared ReadOnly smLiechtensteinIdds As String() = {"00"}
        Private Shared ReadOnly smLiechtensteinNdds As String() = {}
        Private Shared Function InitializeLiechtenstein() As CountryData
            Dim country As New CountryData( _
             "Liechtenstein", "LS", "LI", "LIE", "438", "li", _
             smLiechtensteinCountryCodes, _
             smLiechtensteinIdds, _
             smLiechtensteinNdds)
            Return country
        End Function

        Private Shared ReadOnly smLithuania As CountryData = InitializeLithuania()
        Private Shared ReadOnly smLithuaniaCountryCodes As String() = {"+370"}
        Private Shared ReadOnly smLithuaniaIdds As String() = {"00"}
        Private Shared ReadOnly smLithuaniaNdds As String() = {"8"}
        Private Shared Function InitializeLithuania() As CountryData
            Dim country As New CountryData( _
             "Lithuania", "LH", "LT", "LTU", "440", "lt", _
             smLithuaniaCountryCodes, _
             smLithuaniaIdds, _
             smLithuaniaNdds)
            Return country
        End Function

        Private Shared ReadOnly smLuxembourg As CountryData = InitializeLuxembourg()
        Private Shared ReadOnly smLuxembourgCountryCodes As String() = {"+352"}
        Private Shared ReadOnly smLuxembourgIdds As String() = {"00"}
        Private Shared ReadOnly smLuxembourgNdds As String() = {}
        Private Shared Function InitializeLuxembourg() As CountryData
            Dim country As New CountryData( _
             "Luxembourg", "LU", "LU", "LUX", "442", "lu", _
             smLuxembourgCountryCodes, _
             smLuxembourgIdds, _
             smLuxembourgNdds)
            Return country
        End Function

        Private Shared ReadOnly smMacau As CountryData = InitializeMacau()
        Private Shared ReadOnly smMacauCountryCodes As String() = {"+853"}
        Private Shared ReadOnly smMacauIdds As String() = {"00"}
        Private Shared ReadOnly smMacauNdds As String() = {"0"}
        Private Shared Function InitializeMacau() As CountryData
            Dim country As New CountryData( _
             "Macau", "MC", "MO", "MAC", "446", "mo", _
             smMacauCountryCodes, _
             smMacauIdds, _
             smMacauNdds)
            Return country
        End Function

        Private Shared ReadOnly smMacedonia As CountryData = InitializeMacedonia()
        Private Shared ReadOnly smMacedoniaCountryCodes As String() = {"+389"}
        Private Shared ReadOnly smMacedoniaIdds As String() = {"00"}
        Private Shared ReadOnly smMacedoniaNdds As String() = {"0"}
        Private Shared Function InitializeMacedonia() As CountryData
            Dim country As New CountryData( _
             "Macedonia", "MK", "MK", "MKD", "807", "mk", _
             smMacedoniaCountryCodes, _
             smMacedoniaIdds, _
             smMacedoniaNdds)
            Return country
        End Function

        Private Shared ReadOnly smMadagascar As CountryData = InitializeMadagascar()
        Private Shared ReadOnly smMadagascarCountryCodes As String() = {"+261"}
        Private Shared ReadOnly smMadagascarIdds As String() = {"00"}
        Private Shared ReadOnly smMadagascarNdds As String() = {"0"}
        Private Shared Function InitializeMadagascar() As CountryData
            Dim country As New CountryData( _
             "Madagascar", "MA", "MG", "MDG", "450", "mg", _
             smMadagascarCountryCodes, _
             smMadagascarIdds, _
             smMadagascarNdds)
            Return country
        End Function

        Private Shared ReadOnly smMalawi As CountryData = InitializeMalawi()
        Private Shared ReadOnly smMalawiCountryCodes As String() = {"+265"}
        Private Shared ReadOnly smMalawiIdds As String() = {"00"}
        Private Shared ReadOnly smMalawiNdds As String() = {}
        Private Shared Function InitializeMalawi() As CountryData
            Dim country As New CountryData( _
             "Malawi", "MI", "MW", "MWI", "454", "mw", _
             smMalawiCountryCodes, _
             smMalawiIdds, _
             smMalawiNdds)
            Return country
        End Function

        Private Shared ReadOnly smMalaysia As CountryData = InitializeMalaysia()
        Private Shared ReadOnly smMalaysiaCountryCodes As String() = {"+60"}
        Private Shared ReadOnly smMalaysiaIdds As String() = {"00"}
        Private Shared ReadOnly smMalaysiaNdds As String() = {"0"}
        Private Shared Function InitializeMalaysia() As CountryData
            Dim country As New CountryData( _
             "Malaysia", "MY", "MY", "MYS", "458", "my", _
             smMalaysiaCountryCodes, _
             smMalaysiaIdds, _
             smMalaysiaNdds)
            Return country
        End Function

        Private Shared ReadOnly smMaldives As CountryData = InitializeMaldives()
        Private Shared ReadOnly smMaldivesCountryCodes As String() = {"+960"}
        Private Shared ReadOnly smMaldivesIdds As String() = {"00"}
        Private Shared ReadOnly smMaldivesNdds As String() = {"0"}
        Private Shared Function InitializeMaldives() As CountryData
            Dim country As New CountryData( _
             "Maldives", "MV", "MV", "MDV", "462", "mv", _
             smMaldivesCountryCodes, _
             smMaldivesIdds, _
             smMaldivesNdds)
            Return country
        End Function

        Private Shared ReadOnly smMali As CountryData = InitializeMali()
        Private Shared ReadOnly smMaliCountryCodes As String() = {"+223"}
        Private Shared ReadOnly smMaliIdds As String() = {"00"}
        Private Shared ReadOnly smMaliNdds As String() = {"0"}
        Private Shared Function InitializeMali() As CountryData
            Dim country As New CountryData( _
             "Mali", "ML", "ML", "MLI", "466", "ml", _
             smMaliCountryCodes, _
             smMaliIdds, _
             smMaliNdds)
            Return country
        End Function

        Private Shared ReadOnly smMalta As CountryData = InitializeMalta()
        Private Shared ReadOnly smMaltaCountryCodes As String() = {"+356"}
        Private Shared ReadOnly smMaltaIdds As String() = {"00"}
        Private Shared ReadOnly smMaltaNdds As String() = {"0"}
        Private Shared Function InitializeMalta() As CountryData
            Dim country As New CountryData( _
             "Malta", "MT", "MT", "MLT", "470", "mt", _
             smMaltaCountryCodes, _
             smMaltaIdds, _
             smMaltaNdds)
            Return country
        End Function

        Private Shared ReadOnly smMarshallIslands As CountryData = InitializeMarshallIslands()
        Private Shared ReadOnly smMarshallIslandsCountryCodes As String() = {"+692"}
        Private Shared ReadOnly smMarshallIslandsIdds As String() = {"011"}
        Private Shared ReadOnly smMarshallIslandsNdds As String() = {"1"}
        Private Shared Function InitializeMarshallIslands() As CountryData
            Dim country As New CountryData( _
             "MarshallIslands", "RM", "MH", "MHL", "584", "mh", _
             smMarshallIslandsCountryCodes, _
             smMarshallIslandsIdds, _
             smMarshallIslandsNdds)
            Return country
        End Function

        Private Shared ReadOnly smMartinique As CountryData = InitializeMartinique()
        Private Shared ReadOnly smMartiniqueCountryCodes As String() = {"+596"}
        Private Shared ReadOnly smMartiniqueIdds As String() = {"00"}
        Private Shared ReadOnly smMartiniqueNdds As String() = {"0"}
        Private Shared Function InitializeMartinique() As CountryData
            Dim country As New CountryData( _
             "Martinique", "MB", "MQ", "MTQ", "474", "mq", _
             smMartiniqueCountryCodes, _
             smMartiniqueIdds, _
             smMartiniqueNdds)
            Return country
        End Function

        Private Shared ReadOnly smMauritania As CountryData = InitializeMauritania()
        Private Shared ReadOnly smMauritaniaCountryCodes As String() = {"+222"}
        Private Shared ReadOnly smMauritaniaIdds As String() = {"00"}
        Private Shared ReadOnly smMauritaniaNdds As String() = {"0"}
        Private Shared Function InitializeMauritania() As CountryData
            Dim country As New CountryData( _
             "Mauritania", "MR", "MR", "MRT", "478", "mr", _
             smMauritaniaCountryCodes, _
             smMauritaniaIdds, _
             smMauritaniaNdds)
            Return country
        End Function

        Private Shared ReadOnly smMauritius As CountryData = InitializeMauritius()
        Private Shared ReadOnly smMauritiusCountryCodes As String() = {"+230"}
        Private Shared ReadOnly smMauritiusIdds As String() = {"00"}
        Private Shared ReadOnly smMauritiusNdds As String() = {"0"}
        Private Shared Function InitializeMauritius() As CountryData
            Dim country As New CountryData( _
             "Mauritius", "MP", "MU", "MUS", "480", "mu", _
             smMauritiusCountryCodes, _
             smMauritiusIdds, _
             smMauritiusNdds)
            Return country
        End Function

        Private Shared ReadOnly smMayotte As CountryData = InitializeMayotte()
        Private Shared ReadOnly smMayotteCountryCodes As String() = {"+269"}
        Private Shared ReadOnly smMayotteIdds As String() = {"00"}
        Private Shared ReadOnly smMayotteNdds As String() = {}
        Private Shared Function InitializeMayotte() As CountryData
            Dim country As New CountryData( _
             "Mayotte", "MF", "YT", "MYT", "175", "yt", _
             smMayotteCountryCodes, _
             smMayotteIdds, _
             smMayotteNdds)
            Return country
        End Function

        Private Shared ReadOnly smMexico As CountryData = InitializeMexico()
        Private Shared ReadOnly smMexicoCountryCodes As String() = {"+52"}
        Private Shared ReadOnly smMexicoIdds As String() = {"00"}
        Private Shared ReadOnly smMexicoNdds As String() = {"01"}
        Private Shared Function InitializeMexico() As CountryData
            Dim country As New CountryData( _
             "Mexico", "MX", "MX", "MEX", "484", "mx", _
             smMexicoCountryCodes, _
             smMexicoIdds, _
             smMexicoNdds)
            Return country
        End Function

        Private Shared ReadOnly smMicronesia As CountryData = InitializeMicronesia()
        Private Shared ReadOnly smMicronesiaCountryCodes As String() = {"+691"}
        Private Shared ReadOnly smMicronesiaIdds As String() = {"011"}
        Private Shared ReadOnly smMicronesiaNdds As String() = {"1"}
        Private Shared Function InitializeMicronesia() As CountryData
            Dim country As New CountryData( _
             "Micronesia", "FM", "FM", "FSM", "583", "fm", _
             smMicronesiaCountryCodes, _
             smMicronesiaIdds, _
             smMicronesiaNdds)
            Return country
        End Function

        Private Shared ReadOnly smMoldova As CountryData = InitializeMoldova()
        Private Shared ReadOnly smMoldovaCountryCodes As String() = {"+373"}
        Private Shared ReadOnly smMoldovaIdds As String() = {"00"}
        Private Shared ReadOnly smMoldovaNdds As String() = {"0"}
        Private Shared Function InitializeMoldova() As CountryData
            Dim country As New CountryData( _
             "Moldova", "MD", "MD", "MDA", "498", "md", _
             smMoldovaCountryCodes, _
             smMoldovaIdds, _
             smMoldovaNdds)
            Return country
        End Function

        Private Shared ReadOnly smMonaco As CountryData = InitializeMonaco()
        Private Shared ReadOnly smMonacoCountryCodes As String() = {"+377"}
        Private Shared ReadOnly smMonacoIdds As String() = {"00"}
        Private Shared ReadOnly smMonacoNdds As String() = {"0"}
        Private Shared Function InitializeMonaco() As CountryData
            Dim country As New CountryData( _
             "Monaco", "MN", "MC", "MCO", "492", "mc", _
             smMonacoCountryCodes, _
             smMonacoIdds, _
             smMonacoNdds)
            Return country
        End Function

        Private Shared ReadOnly smMongolia As CountryData = InitializeMongolia()
        Private Shared ReadOnly smMongoliaCountryCodes As String() = {"+976"}
        Private Shared ReadOnly smMongoliaIdds As String() = {"001"}
        Private Shared ReadOnly smMongoliaNdds As String() = {"0"}
        Private Shared Function InitializeMongolia() As CountryData
            Dim country As New CountryData( _
             "Mongolia", "MG", "MN", "MNG", "496", "mn", _
             smMongoliaCountryCodes, _
             smMongoliaIdds, _
             smMongoliaNdds)
            Return country
        End Function

        Private Shared ReadOnly smMontserrat As CountryData = InitializeMontserrat()
        Private Shared ReadOnly smMontserratCountryCodes As String() = {"+1-664"}
        Private Shared ReadOnly smMontserratIdds As String() = {"011"}
        Private Shared ReadOnly smMontserratNdds As String() = {"1"}
        Private Shared Function InitializeMontserrat() As CountryData
            Dim country As New CountryData( _
             "Montserrat", "MH", "MS", "MSR", "500", "ms", _
             smMontserratCountryCodes, _
             smMontserratIdds, _
             smMontserratNdds)
            Return country
        End Function

        Private Shared ReadOnly smMorocco As CountryData = InitializeMorocco()
        Private Shared ReadOnly smMoroccoCountryCodes As String() = {"+212"}
        Private Shared ReadOnly smMoroccoIdds As String() = {"00"}
        Private Shared ReadOnly smMoroccoNdds As String() = {}
        Private Shared Function InitializeMorocco() As CountryData
            Dim country As New CountryData( _
             "Morocco", "MO", "MA", "MAR", "504", "ma", _
             smMoroccoCountryCodes, _
             smMoroccoIdds, _
             smMoroccoNdds)
            Return country
        End Function

        Private Shared ReadOnly smMozambique As CountryData = InitializeMozambique()
        Private Shared ReadOnly smMozambiqueCountryCodes As String() = {"+258"}
        Private Shared ReadOnly smMozambiqueIdds As String() = {"00"}
        Private Shared ReadOnly smMozambiqueNdds As String() = {"0"}
        Private Shared Function InitializeMozambique() As CountryData
            Dim country As New CountryData( _
             "Mozambique", "MZ", "MZ", "MOZ", "508", "mz", _
             smMozambiqueCountryCodes, _
             smMozambiqueIdds, _
             smMozambiqueNdds)
            Return country
        End Function

        Private Shared ReadOnly smNamibia As CountryData = InitializeNamibia()
        Private Shared ReadOnly smNamibiaCountryCodes As String() = {"+264"}
        Private Shared ReadOnly smNamibiaIdds As String() = {"00"}
        Private Shared ReadOnly smNamibiaNdds As String() = {"0"}
        Private Shared Function InitializeNamibia() As CountryData
            Dim country As New CountryData( _
             "Namibia", "WA", "NA", "NAM", "516", "na", _
             smNamibiaCountryCodes, _
             smNamibiaIdds, _
             smNamibiaNdds)
            Return country
        End Function

        Private Shared ReadOnly smNauru As CountryData = InitializeNauru()
        Private Shared ReadOnly smNauruCountryCodes As String() = {"+674"}
        Private Shared ReadOnly smNauruIdds As String() = {"00"}
        Private Shared ReadOnly smNauruNdds As String() = {"0"}
        Private Shared Function InitializeNauru() As CountryData
            Dim country As New CountryData( _
             "Nauru", "NR", "NR", "NRU", "520", "nr", _
             smNauruCountryCodes, _
             smNauruIdds, _
             smNauruNdds)
            Return country
        End Function

        Private Shared ReadOnly smNepal As CountryData = InitializeNepal()
        Private Shared ReadOnly smNepalCountryCodes As String() = {"+977"}
        Private Shared ReadOnly smNepalIdds As String() = {"00"}
        Private Shared ReadOnly smNepalNdds As String() = {"0"}
        Private Shared Function InitializeNepal() As CountryData
            Dim country As New CountryData( _
             "Nepal", "NP", "NP", "NPL", "524", "np", _
             smNepalCountryCodes, _
             smNepalIdds, _
             smNepalNdds)
            Return country
        End Function

        Private Shared ReadOnly smNetherlands As CountryData = InitializeNetherlands()
        Private Shared ReadOnly smNetherlandsCountryCodes As String() = {"+31"}
        Private Shared ReadOnly smNetherlandsIdds As String() = {"00"}
        Private Shared ReadOnly smNetherlandsNdds As String() = {"0"}
        Private Shared Function InitializeNetherlands() As CountryData
            Dim country As New CountryData( _
             "Netherlands", "NL", "NL", "NLD", "528", "nl", _
             smNetherlandsCountryCodes, _
             smNetherlandsIdds, _
             smNetherlandsNdds)
            Return country
        End Function

        Private Shared ReadOnly smNetherlandsAntilles As CountryData = InitializeNetherlandsAntilles()
        Private Shared ReadOnly smNetherlandsAntillesCountryCodes As String() = {"+599"}
        Private Shared ReadOnly smNetherlandsAntillesIdds As String() = {"00"}
        Private Shared ReadOnly smNetherlandsAntillesNdds As String() = {"0"}
        Private Shared Function InitializeNetherlandsAntilles() As CountryData
            Dim country As New CountryData( _
             "NetherlandsAntilles", "NT", "AN", "ANT", "530", "an", _
             smNetherlandsAntillesCountryCodes, _
             smNetherlandsAntillesIdds, _
             smNetherlandsAntillesNdds)
            Return country
        End Function

        Private Shared ReadOnly smNewCaledonia As CountryData = InitializeNewCaledonia()
        Private Shared ReadOnly smNewCaledoniaCountryCodes As String() = {"+687"}
        Private Shared ReadOnly smNewCaledoniaIdds As String() = {"00"}
        Private Shared ReadOnly smNewCaledoniaNdds As String() = {"0"}
        Private Shared Function InitializeNewCaledonia() As CountryData
            Dim country As New CountryData( _
             "NewCaledonia", "NC", "NC", "NCL", "540", "nc", _
             smNewCaledoniaCountryCodes, _
             smNewCaledoniaIdds, _
             smNewCaledoniaNdds)
            Return country
        End Function

        Private Shared ReadOnly smNewZealand As CountryData = InitializeNewZealand()
        Private Shared ReadOnly smNewZealandCountryCodes As String() = {"+64"}
        Private Shared ReadOnly smNewZealandIdds As String() = {"00"}
        Private Shared ReadOnly smNewZealandNdds As String() = {"0"}
        Private Shared Function InitializeNewZealand() As CountryData
            Dim country As New CountryData( _
             "NewZealand", "NZ", "NZ", "NZL", "554", "nz", _
             smNewZealandCountryCodes, _
             smNewZealandIdds, _
             smNewZealandNdds)
            Return country
        End Function

        Private Shared ReadOnly smNicaragua As CountryData = InitializeNicaragua()
        Private Shared ReadOnly smNicaraguaCountryCodes As String() = {"+505"}
        Private Shared ReadOnly smNicaraguaIdds As String() = {"00"}
        Private Shared ReadOnly smNicaraguaNdds As String() = {"0"}
        Private Shared Function InitializeNicaragua() As CountryData
            Dim country As New CountryData( _
             "Nicaragua", "NU", "NI", "NIC", "558", "ni", _
             smNicaraguaCountryCodes, _
             smNicaraguaIdds, _
             smNicaraguaNdds)
            Return country
        End Function

        Private Shared ReadOnly smNiger As CountryData = InitializeNiger()
        Private Shared ReadOnly smNigerCountryCodes As String() = {"+227"}
        Private Shared ReadOnly smNigerIdds As String() = {"00"}
        Private Shared ReadOnly smNigerNdds As String() = {"0"}
        Private Shared Function InitializeNiger() As CountryData
            Dim country As New CountryData( _
             "Niger", "NG", "NE", "NER", "562", "ne", _
             smNigerCountryCodes, _
             smNigerIdds, _
             smNigerNdds)
            Return country
        End Function

        Private Shared ReadOnly smNigeria As CountryData = InitializeNigeria()
        Private Shared ReadOnly smNigeriaCountryCodes As String() = {"+234"}
        Private Shared ReadOnly smNigeriaIdds As String() = {"009"}
        Private Shared ReadOnly smNigeriaNdds As String() = {"0"}
        Private Shared Function InitializeNigeria() As CountryData
            Dim country As New CountryData( _
             "Nigeria", "NI", "NG", "NGA", "566", "ng", _
             smNigeriaCountryCodes, _
             smNigeriaIdds, _
             smNigeriaNdds)
            Return country
        End Function

        Private Shared ReadOnly smNiue As CountryData = InitializeNiue()
        Private Shared ReadOnly smNiueCountryCodes As String() = {"+683"}
        Private Shared ReadOnly smNiueIdds As String() = {"00"}
        Private Shared ReadOnly smNiueNdds As String() = {"0"}
        Private Shared Function InitializeNiue() As CountryData
            Dim country As New CountryData( _
             "Niue", "NE", "NU", "NIU", "570", "nu", _
             smNiueCountryCodes, _
             smNiueIdds, _
             smNiueNdds)
            Return country
        End Function

        Private Shared ReadOnly smNorfolkIsland As CountryData = InitializeNorfolkIsland()
        Private Shared ReadOnly smNorfolkIslandCountryCodes As String() = {"+672"}
        Private Shared ReadOnly smNorfolkIslandIdds As String() = {"00"}
        Private Shared ReadOnly smNorfolkIslandNdds As String() = {}
        Private Shared Function InitializeNorfolkIsland() As CountryData
            Dim country As New CountryData( _
             "NorfolkIsland", "NF", "NF", "NFK", "574", "nf", _
             smNorfolkIslandCountryCodes, _
             smNorfolkIslandIdds, _
             smNorfolkIslandNdds)
            Return country
        End Function

        Private Shared ReadOnly smNorthernMarianaIslands As CountryData = InitializeNorthernMarianaIslands()
        Private Shared ReadOnly smNorthernMarianaIslandsCountryCodes As String() = {"+1-670"}
        Private Shared ReadOnly smNorthernMarianaIslandsIdds As String() = {"011"}
        Private Shared ReadOnly smNorthernMarianaIslandsNdds As String() = {"1"}
        Private Shared Function InitializeNorthernMarianaIslands() As CountryData
            Dim country As New CountryData( _
             "NorthernMarianaIslands", "CQ", "MP", "MNP", "580", "mp", _
             smNorthernMarianaIslandsCountryCodes, _
             smNorthernMarianaIslandsIdds, _
             smNorthernMarianaIslandsNdds)
            Return country
        End Function

        Private Shared ReadOnly smNorway As CountryData = InitializeNorway()
        Private Shared ReadOnly smNorwayCountryCodes As String() = {"+47"}
        Private Shared ReadOnly smNorwayIdds As String() = {"00"}
        Private Shared ReadOnly smNorwayNdds As String() = {}
        Private Shared Function InitializeNorway() As CountryData
            Dim country As New CountryData( _
             "Norway", "NO", "NO", "NOR", "578", "no", _
             smNorwayCountryCodes, _
             smNorwayIdds, _
             smNorwayNdds)
            Return country
        End Function

        Private Shared ReadOnly smOman As CountryData = InitializeOman()
        Private Shared ReadOnly smOmanCountryCodes As String() = {"+968"}
        Private Shared ReadOnly smOmanIdds As String() = {"00"}
        Private Shared ReadOnly smOmanNdds As String() = {"0"}
        Private Shared Function InitializeOman() As CountryData
            Dim country As New CountryData( _
             "Oman", "MU", "OM", "OMN", "512", "om", _
             smOmanCountryCodes, _
             smOmanIdds, _
             smOmanNdds)
            Return country
        End Function

        Private Shared ReadOnly smPakistan As CountryData = InitializePakistan()
        Private Shared ReadOnly smPakistanCountryCodes As String() = {"+92"}
        Private Shared ReadOnly smPakistanIdds As String() = {"00"}
        Private Shared ReadOnly smPakistanNdds As String() = {"0"}
        Private Shared Function InitializePakistan() As CountryData
            Dim country As New CountryData( _
             "Pakistan", "PK", "PK", "PAK", "586", "pk", _
             smPakistanCountryCodes, _
             smPakistanIdds, _
             smPakistanNdds)
            Return country
        End Function

        Private Shared ReadOnly smPalau As CountryData = InitializePalau()
        Private Shared ReadOnly smPalauCountryCodes As String() = {"+680"}
        Private Shared ReadOnly smPalauIdds As String() = {"011"}
        Private Shared ReadOnly smPalauNdds As String() = {}
        Private Shared Function InitializePalau() As CountryData
            Dim country As New CountryData( _
             "Palau", "PS", "PW", "PLW", "585", "pw", _
             smPalauCountryCodes, _
             smPalauIdds, _
             smPalauNdds)
            Return country
        End Function

        Private Shared ReadOnly smPanama As CountryData = InitializePanama()
        Private Shared ReadOnly smPanamaCountryCodes As String() = {"+507"}
        Private Shared ReadOnly smPanamaIdds As String() = {"00", "088+00", "055+00"}
        Private Shared ReadOnly smPanamaNdds As String() = {"0"}
        Private Shared Function InitializePanama() As CountryData
            Dim country As New CountryData( _
             "Panama", "PM", "PA", "PAN", "591", "pa", _
             smPanamaCountryCodes, _
             smPanamaIdds, _
             smPanamaNdds)
            Return country
        End Function

        Private Shared ReadOnly smPapuaNewGuinea As CountryData = InitializePapuaNewGuinea()
        Private Shared ReadOnly smPapuaNewGuineaCountryCodes As String() = {"+675"}
        Private Shared ReadOnly smPapuaNewGuineaIdds As String() = {"05"}
        Private Shared ReadOnly smPapuaNewGuineaNdds As String() = {}
        Private Shared Function InitializePapuaNewGuinea() As CountryData
            Dim country As New CountryData( _
             "PapuaNewGuinea", "PP", "PG", "PNG", "598", "pg", _
             smPapuaNewGuineaCountryCodes, _
             smPapuaNewGuineaIdds, _
             smPapuaNewGuineaNdds)
            Return country
        End Function

        Private Shared ReadOnly smParaguay As CountryData = InitializeParaguay()
        Private Shared ReadOnly smParaguayCountryCodes As String() = {"+595"}
        Private Shared ReadOnly smParaguayIdds As String() = {"002"}
        Private Shared ReadOnly smParaguayNdds As String() = {"0"}
        Private Shared Function InitializeParaguay() As CountryData
            Dim country As New CountryData( _
             "Paraguay", "PA", "PY", "PRY", "600", "py", _
             smParaguayCountryCodes, _
             smParaguayIdds, _
             smParaguayNdds)
            Return country
        End Function

        Private Shared ReadOnly smPeru As CountryData = InitializePeru()
        Private Shared ReadOnly smPeruCountryCodes As String() = {"+51"}
        Private Shared ReadOnly smPeruIdds As String() = {"00"}
        Private Shared ReadOnly smPeruNdds As String() = {"0"}
        Private Shared Function InitializePeru() As CountryData
            Dim country As New CountryData( _
             "Peru", "PE", "PE", "PER", "604", "pe", _
             smPeruCountryCodes, _
             smPeruIdds, _
             smPeruNdds)
            Return country
        End Function

        Private Shared ReadOnly smPhilippines As CountryData = InitializePhilippines()
        Private Shared ReadOnly smPhilippinesCountryCodes As String() = {"+63"}
        Private Shared ReadOnly smPhilippinesIdds As String() = {"00"}
        Private Shared ReadOnly smPhilippinesNdds As String() = {"0"}
        Private Shared Function InitializePhilippines() As CountryData
            Dim country As New CountryData( _
             "Philippines", "RP", "PH", "PHL", "608", "ph", _
             smPhilippinesCountryCodes, _
             smPhilippinesIdds, _
             smPhilippinesNdds)
            Return country
        End Function

        Private Shared ReadOnly smPitcairnIslands As CountryData = InitializePitcairnIslands()
        Private Shared ReadOnly smPitcairnIslandsCountryCodes As String() = {}
        Private Shared ReadOnly smPitcairnIslandsIdds As String() = {}
        Private Shared ReadOnly smPitcairnIslandsNdds As String() = {}
        Private Shared Function InitializePitcairnIslands() As CountryData
            Dim country As New CountryData( _
             "PitcairnIslands", "PC", "PN", "PCN", "612", "pn", _
             smPitcairnIslandsCountryCodes, _
             smPitcairnIslandsIdds, _
             smPitcairnIslandsNdds)
            Return country
        End Function

        Private Shared ReadOnly smPoland As CountryData = InitializePoland()
        Private Shared ReadOnly smPolandCountryCodes As String() = {"+48"}
        Private Shared ReadOnly smPolandIdds As String() = {"0~0"}
        Private Shared ReadOnly smPolandNdds As String() = {"0"}
        Private Shared Function InitializePoland() As CountryData
            Dim country As New CountryData( _
             "Poland", "PL", "PL", "POL", "616", "pl", _
             smPolandCountryCodes, _
             smPolandIdds, _
             smPolandNdds)
            Return country
        End Function

        Private Shared ReadOnly smPortugal As CountryData = InitializePortugal()
        Private Shared ReadOnly smPortugalCountryCodes As String() = {"+351"}
        Private Shared ReadOnly smPortugalIdds As String() = {"00", "882"}
        Private Shared ReadOnly smPortugalNdds As String() = {}
        Private Shared Function InitializePortugal() As CountryData
            Dim country As New CountryData( _
             "Portugal", "PO", "PT", "PRT", "620", "pt", _
             smPortugalCountryCodes, _
             smPortugalIdds, _
             smPortugalNdds)
            Return country
        End Function

        Private Shared ReadOnly smPuertoRico As CountryData = InitializePuertoRico()
        Private Shared ReadOnly smPuertoRicoCountryCodes As String() = {"+1-787", "+1-939"}
        Private Shared ReadOnly smPuertoRicoIdds As String() = {"011"}
        Private Shared ReadOnly smPuertoRicoNdds As String() = {"1"}
        Private Shared Function InitializePuertoRico() As CountryData
            Dim country As New CountryData( _
             "PuertoRico", "RQ", "PR", "PRI", "630", "pr", _
             smPuertoRicoCountryCodes, _
             smPuertoRicoIdds, _
             smPuertoRicoNdds)
            Return country
        End Function

        Private Shared ReadOnly smQatar As CountryData = InitializeQatar()
        Private Shared ReadOnly smQatarCountryCodes As String() = {"+974"}
        Private Shared ReadOnly smQatarIdds As String() = {"00"}
        Private Shared ReadOnly smQatarNdds As String() = {"0"}
        Private Shared Function InitializeQatar() As CountryData
            Dim country As New CountryData( _
             "Qatar", "QA", "QA", "QAT", "634", "qa", _
             smQatarCountryCodes, _
             smQatarIdds, _
             smQatarNdds)
            Return country
        End Function

        Private Shared ReadOnly smReunion As CountryData = InitializeReunion()
        Private Shared ReadOnly smReunionCountryCodes As String() = {"+262"}
        Private Shared ReadOnly smReunionIdds As String() = {"00"}
        Private Shared ReadOnly smReunionNdds As String() = {"0"}
        Private Shared Function InitializeReunion() As CountryData
            Dim country As New CountryData( _
             "Reunion", "RE", "RE", "REU", "638", "re", _
             smReunionCountryCodes, _
             smReunionIdds, _
             smReunionNdds)
            Return country
        End Function

        Private Shared ReadOnly smRomania As CountryData = InitializeRomania()
        Private Shared ReadOnly smRomaniaCountryCodes As String() = {"+40"}
        Private Shared ReadOnly smRomaniaIdds As String() = {"00"}
        Private Shared ReadOnly smRomaniaNdds As String() = {"0"}
        Private Shared Function InitializeRomania() As CountryData
            Dim country As New CountryData( _
             "Romania", "RO", "RO", "ROU", "642", "ro", _
             smRomaniaCountryCodes, _
             smRomaniaIdds, _
             smRomaniaNdds)
            Return country
        End Function

        Private Shared ReadOnly smRussia As CountryData = InitializeRussia()
        Private Shared ReadOnly smRussiaCountryCodes As String() = {"+7"}
        Private Shared ReadOnly smRussiaIdds As String() = {"8~10", "00"}
        Private Shared ReadOnly smRussiaNdds As String() = {"8", "0"}
        Private Shared Function InitializeRussia() As CountryData
            Dim country As New CountryData( _
             "Russia", "RS", "RU", "RUS", "643", "ru", _
             smRussiaCountryCodes, _
             smRussiaIdds, _
             smRussiaNdds)
            Return country
        End Function

        Private Shared ReadOnly smRwanda As CountryData = InitializeRwanda()
        Private Shared ReadOnly smRwandaCountryCodes As String() = {"+250"}
        Private Shared ReadOnly smRwandaIdds As String() = {"00"}
        Private Shared ReadOnly smRwandaNdds As String() = {"0"}
        Private Shared Function InitializeRwanda() As CountryData
            Dim country As New CountryData( _
             "Rwanda", "RW", "RW", "RWA", "646", "rw", _
             smRwandaCountryCodes, _
             smRwandaIdds, _
             smRwandaNdds)
            Return country
        End Function

        Private Shared ReadOnly smSaintHelena As CountryData = InitializeSaintHelena()
        Private Shared ReadOnly smSaintHelenaCountryCodes As String() = {"+290"}
        Private Shared ReadOnly smSaintHelenaIdds As String() = {"00"}
        Private Shared ReadOnly smSaintHelenaNdds As String() = {}
        Private Shared Function InitializeSaintHelena() As CountryData
            Dim country As New CountryData( _
             "SaintHelena", "SH", "SH", "SHN", "654", "sh", _
             smSaintHelenaCountryCodes, _
             smSaintHelenaIdds, _
             smSaintHelenaNdds)
            Return country
        End Function

        Private Shared ReadOnly smSaintKittsNevis As CountryData = InitializeSaintKittsNevis()
        Private Shared ReadOnly smSaintKittsNevisCountryCodes As String() = {"+1-869"}
        Private Shared ReadOnly smSaintKittsNevisIdds As String() = {"011"}
        Private Shared ReadOnly smSaintKittsNevisNdds As String() = {"1"}
        Private Shared Function InitializeSaintKittsNevis() As CountryData
            Dim country As New CountryData( _
             "SaintKittsNevis", "SC", "KN", "KNA", "659", "kn", _
             smSaintKittsNevisCountryCodes, _
             smSaintKittsNevisIdds, _
             smSaintKittsNevisNdds)
            Return country
        End Function

        Private Shared ReadOnly smSaintLucia As CountryData = InitializeSaintLucia()
        Private Shared ReadOnly smSaintLuciaCountryCodes As String() = {"+1-758"}
        Private Shared ReadOnly smSaintLuciaIdds As String() = {"011"}
        Private Shared ReadOnly smSaintLuciaNdds As String() = {"1"}
        Private Shared Function InitializeSaintLucia() As CountryData
            Dim country As New CountryData( _
             "SaintLucia", "ST", "LC", "LCA", "662", "lc", _
             smSaintLuciaCountryCodes, _
             smSaintLuciaIdds, _
             smSaintLuciaNdds)
            Return country
        End Function

        Private Shared ReadOnly smSaintPierreMiquelon As CountryData = InitializeSaintPierreMiquelon()
        Private Shared ReadOnly smSaintPierreMiquelonCountryCodes As String() = {"+508"}
        Private Shared ReadOnly smSaintPierreMiquelonIdds As String() = {"00"}
        Private Shared ReadOnly smSaintPierreMiquelonNdds As String() = {"0"}
        Private Shared Function InitializeSaintPierreMiquelon() As CountryData
            Dim country As New CountryData( _
             "SaintPierreMiquelon", "SB", "PM", "SPM", "666", "pm", _
             smSaintPierreMiquelonCountryCodes, _
             smSaintPierreMiquelonIdds, _
             smSaintPierreMiquelonNdds)
            Return country
        End Function

        Private Shared ReadOnly smSaintVincentGrenadines As CountryData = InitializeSaintVincentGrenadines()
        Private Shared ReadOnly smSaintVincentGrenadinesCountryCodes As String() = {"+1-784"}
        Private Shared ReadOnly smSaintVincentGrenadinesIdds As String() = {"011"}
        Private Shared ReadOnly smSaintVincentGrenadinesNdds As String() = {"1"}
        Private Shared Function InitializeSaintVincentGrenadines() As CountryData
            Dim country As New CountryData( _
             "SaintVincentGrenadines", "VC", "VC", "VCT", "670", "vc", _
             smSaintVincentGrenadinesCountryCodes, _
             smSaintVincentGrenadinesIdds, _
             smSaintVincentGrenadinesNdds)
            Return country
        End Function

        Private Shared ReadOnly smSamoa As CountryData = InitializeSamoa()
        Private Shared ReadOnly smSamoaCountryCodes As String() = {"+685"}
        Private Shared ReadOnly smSamoaIdds As String() = {"00"}
        Private Shared ReadOnly smSamoaNdds As String() = {}
        Private Shared Function InitializeSamoa() As CountryData
            Dim country As New CountryData( _
             "Samoa", "WS", "WS", "WSM", "882", "ws", _
             smSamoaCountryCodes, _
             smSamoaIdds, _
             smSamoaNdds)
            Return country
        End Function

        Private Shared ReadOnly smSanMarino As CountryData = InitializeSanMarino()
        Private Shared ReadOnly smSanMarinoCountryCodes As String() = {"+378"}
        Private Shared ReadOnly smSanMarinoIdds As String() = {"00"}
        Private Shared ReadOnly smSanMarinoNdds As String() = {"0"}
        Private Shared Function InitializeSanMarino() As CountryData
            Dim country As New CountryData( _
             "SanMarino", "SM", "SM", "SMR", "674", "sm", _
             smSanMarinoCountryCodes, _
             smSanMarinoIdds, _
             smSanMarinoNdds)
            Return country
        End Function

        Private Shared ReadOnly smSaoTome As CountryData = InitializeSaoTome()
        Private Shared ReadOnly smSaoTomeCountryCodes As String() = {"+239"}
        Private Shared ReadOnly smSaoTomeIdds As String() = {"00"}
        Private Shared ReadOnly smSaoTomeNdds As String() = {"0"}
        Private Shared Function InitializeSaoTome() As CountryData
            Dim country As New CountryData( _
             "SaoTome", "TP", "ST", "STP", "678", "st", _
             smSaoTomeCountryCodes, _
             smSaoTomeIdds, _
             smSaoTomeNdds)
            Return country
        End Function

        Private Shared ReadOnly smSaudiArabia As CountryData = InitializeSaudiArabia()
        Private Shared ReadOnly smSaudiArabiaCountryCodes As String() = {"+966"}
        Private Shared ReadOnly smSaudiArabiaIdds As String() = {"00"}
        Private Shared ReadOnly smSaudiArabiaNdds As String() = {"0"}
        Private Shared Function InitializeSaudiArabia() As CountryData
            Dim country As New CountryData( _
             "SaudiArabia", "SA", "SA", "SAU", "682", "sa", _
             smSaudiArabiaCountryCodes, _
             smSaudiArabiaIdds, _
             smSaudiArabiaNdds)
            Return country
        End Function

        Private Shared ReadOnly smSenegal As CountryData = InitializeSenegal()
        Private Shared ReadOnly smSenegalCountryCodes As String() = {"+221"}
        Private Shared ReadOnly smSenegalIdds As String() = {"00"}
        Private Shared ReadOnly smSenegalNdds As String() = {"0"}
        Private Shared Function InitializeSenegal() As CountryData
            Dim country As New CountryData( _
             "Senegal", "SG", "SN", "SEN", "686", "sn", _
             smSenegalCountryCodes, _
             smSenegalIdds, _
             smSenegalNdds)
            Return country
        End Function

        Private Shared ReadOnly smSerbiaMontenegro As CountryData = InitializeSerbiaMontenegro()
        Private Shared ReadOnly smSerbiaMontenegroCountryCodes As String() = {"+381"}
        Private Shared ReadOnly smSerbiaMontenegroIdds As String() = {"99"}
        Private Shared ReadOnly smSerbiaMontenegroNdds As String() = {"0"}
        Private Shared Function InitializeSerbiaMontenegro() As CountryData
            Dim country As New CountryData( _
             "SerbiaMontenegro", "YI", "CS", "SCG", "891", "cs", _
             smSerbiaMontenegroCountryCodes, _
             smSerbiaMontenegroIdds, _
             smSerbiaMontenegroNdds)
            Return country
        End Function

        Private Shared ReadOnly smSeychelles As CountryData = InitializeSeychelles()
        Private Shared ReadOnly smSeychellesCountryCodes As String() = {"+248"}
        Private Shared ReadOnly smSeychellesIdds As String() = {"00"}
        Private Shared ReadOnly smSeychellesNdds As String() = {"0"}
        Private Shared Function InitializeSeychelles() As CountryData
            Dim country As New CountryData( _
             "Seychelles", "SE", "SC", "SYC", "690", "sc", _
             smSeychellesCountryCodes, _
             smSeychellesIdds, _
             smSeychellesNdds)
            Return country
        End Function

        Private Shared ReadOnly smSierraLeone As CountryData = InitializeSierraLeone()
        Private Shared ReadOnly smSierraLeoneCountryCodes As String() = {"+232"}
        Private Shared ReadOnly smSierraLeoneIdds As String() = {"00"}
        Private Shared ReadOnly smSierraLeoneNdds As String() = {"0"}
        Private Shared Function InitializeSierraLeone() As CountryData
            Dim country As New CountryData( _
             "SierraLeone", "SL", "SL", "SLE", "694", "sl", _
             smSierraLeoneCountryCodes, _
             smSierraLeoneIdds, _
             smSierraLeoneNdds)
            Return country
        End Function

        Private Shared ReadOnly smSingapore As CountryData = InitializeSingapore()
        Private Shared ReadOnly smSingaporeCountryCodes As String() = {"+65"}
        Private Shared ReadOnly smSingaporeIdds As String() = {"001", "002", "008", "012", "013", "018", "019"}
        Private Shared ReadOnly smSingaporeNdds As String() = {}
        Private Shared Function InitializeSingapore() As CountryData
            Dim country As New CountryData( _
             "Singapore", "SN", "SG", "SGP", "702", "sg", _
             smSingaporeCountryCodes, _
             smSingaporeIdds, _
             smSingaporeNdds)
            Return country
        End Function

        Private Shared ReadOnly smSlovakia As CountryData = InitializeSlovakia()
        Private Shared ReadOnly smSlovakiaCountryCodes As String() = {"+421"}
        Private Shared ReadOnly smSlovakiaIdds As String() = {"00"}
        Private Shared ReadOnly smSlovakiaNdds As String() = {"0"}
        Private Shared Function InitializeSlovakia() As CountryData
            Dim country As New CountryData( _
             "Slovakia", "LO", "SK", "SVK", "703", "sk", _
             smSlovakiaCountryCodes, _
             smSlovakiaIdds, _
             smSlovakiaNdds)
            Return country
        End Function

        Private Shared ReadOnly smSlovenia As CountryData = InitializeSlovenia()
        Private Shared ReadOnly smSloveniaCountryCodes As String() = {"+386"}
        Private Shared ReadOnly smSloveniaIdds As String() = {"00"}
        Private Shared ReadOnly smSloveniaNdds As String() = {"0"}
        Private Shared Function InitializeSlovenia() As CountryData
            Dim country As New CountryData( _
             "Slovenia", "SI", "SI", "SVN", "705", "si", _
             smSloveniaCountryCodes, _
             smSloveniaIdds, _
             smSloveniaNdds)
            Return country
        End Function

        Private Shared ReadOnly smSolomonIslands As CountryData = InitializeSolomonIslands()
        Private Shared ReadOnly smSolomonIslandsCountryCodes As String() = {"+677"}
        Private Shared ReadOnly smSolomonIslandsIdds As String() = {"00"}
        Private Shared ReadOnly smSolomonIslandsNdds As String() = {}
        Private Shared Function InitializeSolomonIslands() As CountryData
            Dim country As New CountryData( _
             "SolomonIslands", "BP", "SB", "SLB", "90", "sb", _
             smSolomonIslandsCountryCodes, _
             smSolomonIslandsIdds, _
             smSolomonIslandsNdds)
            Return country
        End Function

        Private Shared ReadOnly smSomalia As CountryData = InitializeSomalia()
        Private Shared ReadOnly smSomaliaCountryCodes As String() = {"+252"}
        Private Shared ReadOnly smSomaliaIdds As String() = {"00"}
        Private Shared ReadOnly smSomaliaNdds As String() = {}
        Private Shared Function InitializeSomalia() As CountryData
            Dim country As New CountryData( _
             "Somalia", "SO", "SO", "SOM", "706", "so", _
             smSomaliaCountryCodes, _
             smSomaliaIdds, _
             smSomaliaNdds)
            Return country
        End Function

        Private Shared ReadOnly smSouthAfrica As CountryData = InitializeSouthAfrica()
        Private Shared ReadOnly smSouthAfricaCountryCodes As String() = {"+27"}
        Private Shared ReadOnly smSouthAfricaIdds As String() = {"09"}
        Private Shared ReadOnly smSouthAfricaNdds As String() = {"0"}
        Private Shared Function InitializeSouthAfrica() As CountryData
            Dim country As New CountryData( _
             "SouthAfrica", "SF", "ZA", "ZAF", "710", "za", _
             smSouthAfricaCountryCodes, _
             smSouthAfricaIdds, _
             smSouthAfricaNdds)
            Return country
        End Function

        Private Shared ReadOnly smSouthGeorgiaIslands As CountryData = InitializeSouthGeorgiaIslands()
        Private Shared ReadOnly smSouthGeorgiaIslandsCountryCodes As String() = {}
        Private Shared ReadOnly smSouthGeorgiaIslandsIdds As String() = {}
        Private Shared ReadOnly smSouthGeorgiaIslandsNdds As String() = {}
        Private Shared Function InitializeSouthGeorgiaIslands() As CountryData
            Dim country As New CountryData( _
             "SouthGeorgiaIslands", "SX", "GS", "SGS", "239", "gs", _
             smSouthGeorgiaIslandsCountryCodes, _
             smSouthGeorgiaIslandsIdds, _
             smSouthGeorgiaIslandsNdds)
            Return country
        End Function

        Private Shared ReadOnly smSpain As CountryData = InitializeSpain()
        Private Shared ReadOnly smSpainCountryCodes As String() = {"+34"}
        Private Shared ReadOnly smSpainIdds As String() = {"00"}
        Private Shared ReadOnly smSpainNdds As String() = {}
        Private Shared Function InitializeSpain() As CountryData
            Dim country As New CountryData( _
             "Spain", "SP", "ES", "ESP", "724", "es", _
             smSpainCountryCodes, _
             smSpainIdds, _
             smSpainNdds)
            Return country
        End Function

        Private Shared ReadOnly smSriLanka As CountryData = InitializeSriLanka()
        Private Shared ReadOnly smSriLankaCountryCodes As String() = {"+94"}
        Private Shared ReadOnly smSriLankaIdds As String() = {"00"}
        Private Shared ReadOnly smSriLankaNdds As String() = {"0"}
        Private Shared Function InitializeSriLanka() As CountryData
            Dim country As New CountryData( _
             "SriLanka", "CE", "LK", "LKA", "144", "lk", _
             smSriLankaCountryCodes, _
             smSriLankaIdds, _
             smSriLankaNdds)
            Return country
        End Function

        Private Shared ReadOnly smSudan As CountryData = InitializeSudan()
        Private Shared ReadOnly smSudanCountryCodes As String() = {"+249"}
        Private Shared ReadOnly smSudanIdds As String() = {"00"}
        Private Shared ReadOnly smSudanNdds As String() = {"0"}
        Private Shared Function InitializeSudan() As CountryData
            Dim country As New CountryData( _
             "Sudan", "SU", "SD", "SDN", "736", "sd", _
             smSudanCountryCodes, _
             smSudanIdds, _
             smSudanNdds)
            Return country
        End Function

        Private Shared ReadOnly smSuriname As CountryData = InitializeSuriname()
        Private Shared ReadOnly smSurinameCountryCodes As String() = {"+597"}
        Private Shared ReadOnly smSurinameIdds As String() = {"00"}
        Private Shared ReadOnly smSurinameNdds As String() = {}
        Private Shared Function InitializeSuriname() As CountryData
            Dim country As New CountryData( _
             "Suriname", "NS", "SR", "SUR", "740", "sr", _
             smSurinameCountryCodes, _
             smSurinameIdds, _
             smSurinameNdds)
            Return country
        End Function

        Private Shared ReadOnly smSvalbard As CountryData = InitializeSvalbard()
        Private Shared ReadOnly smSvalbardCountryCodes As String() = {}
        Private Shared ReadOnly smSvalbardIdds As String() = {}
        Private Shared ReadOnly smSvalbardNdds As String() = {}
        Private Shared Function InitializeSvalbard() As CountryData
            Dim country As New CountryData( _
             "Svalbard", "SV", "SJ", "SJM", "744", "sj", _
             smSvalbardCountryCodes, _
             smSvalbardIdds, _
             smSvalbardNdds)
            Return country
        End Function

        Private Shared ReadOnly smSwaziland As CountryData = InitializeSwaziland()
        Private Shared ReadOnly smSwazilandCountryCodes As String() = {"+268"}
        Private Shared ReadOnly smSwazilandIdds As String() = {"00"}
        Private Shared ReadOnly smSwazilandNdds As String() = {}
        Private Shared Function InitializeSwaziland() As CountryData
            Dim country As New CountryData( _
             "Swaziland", "WZ", "SZ", "SWZ", "748", "sz", _
             smSwazilandCountryCodes, _
             smSwazilandIdds, _
             smSwazilandNdds)
            Return country
        End Function

        Private Shared ReadOnly smSweden As CountryData = InitializeSweden()
        Private Shared ReadOnly smSwedenCountryCodes As String() = {"+46"}
        Private Shared ReadOnly smSwedenIdds As String() = {"00"}
        Private Shared ReadOnly smSwedenNdds As String() = {"0"}
        Private Shared Function InitializeSweden() As CountryData
            Dim country As New CountryData( _
             "Sweden", "SW", "SE", "SWE", "752", "se", _
             smSwedenCountryCodes, _
             smSwedenIdds, _
             smSwedenNdds)
            Return country
        End Function

        Private Shared ReadOnly smSwitzerland As CountryData = InitializeSwitzerland()
        Private Shared ReadOnly smSwitzerlandCountryCodes As String() = {"+41"}
        Private Shared ReadOnly smSwitzerlandIdds As String() = {"00"}
        Private Shared ReadOnly smSwitzerlandNdds As String() = {"0"}
        Private Shared Function InitializeSwitzerland() As CountryData
            Dim country As New CountryData( _
             "Switzerland", "SZ", "CH", "CHE", "756", "ch", _
             smSwitzerlandCountryCodes, _
             smSwitzerlandIdds, _
             smSwitzerlandNdds)
            Return country
        End Function

        Private Shared ReadOnly smSyria As CountryData = InitializeSyria()
        Private Shared ReadOnly smSyriaCountryCodes As String() = {"+963"}
        Private Shared ReadOnly smSyriaIdds As String() = {"00"}
        Private Shared ReadOnly smSyriaNdds As String() = {"0"}
        Private Shared Function InitializeSyria() As CountryData
            Dim country As New CountryData( _
             "Syria", "SY", "SY", "SYR", "760", "sy", _
             smSyriaCountryCodes, _
             smSyriaIdds, _
             smSyriaNdds)
            Return country
        End Function

        Private Shared ReadOnly smTaiwan As CountryData = InitializeTaiwan()
        Private Shared ReadOnly smTaiwanCountryCodes As String() = {"+866"}
        Private Shared ReadOnly smTaiwanIdds As String() = {"002"}
        Private Shared ReadOnly smTaiwanNdds As String() = {}
        Private Shared Function InitializeTaiwan() As CountryData
            Dim country As New CountryData( _
             "Taiwan", "TW", "TW", "TWN", "158", "tw", _
             smTaiwanCountryCodes, _
             smTaiwanIdds, _
             smTaiwanNdds)
            Return country
        End Function

        Private Shared ReadOnly smTajikistan As CountryData = InitializeTajikistan()
        Private Shared ReadOnly smTajikistanCountryCodes As String() = {"+993"}
        Private Shared ReadOnly smTajikistanIdds As String() = {"8~10"}
        Private Shared ReadOnly smTajikistanNdds As String() = {"8"}
        Private Shared Function InitializeTajikistan() As CountryData
            Dim country As New CountryData( _
             "Tajikistan", "TI", "TJ", "TJK", "762", "tj", _
             smTajikistanCountryCodes, _
             smTajikistanIdds, _
             smTajikistanNdds)
            Return country
        End Function

        Private Shared ReadOnly smTanzania As CountryData = InitializeTanzania()
        Private Shared ReadOnly smTanzaniaCountryCodes As String() = {"+255"}
        Private Shared ReadOnly smTanzaniaIdds As String() = {"000", "005", "006"}
        Private Shared ReadOnly smTanzaniaNdds As String() = {"0"}
        Private Shared Function InitializeTanzania() As CountryData
            Dim country As New CountryData( _
             "Tanzania", "TZ", "TZ", "TZA", "834", "tz", _
             smTanzaniaCountryCodes, _
             smTanzaniaIdds, _
             smTanzaniaNdds)
            Return country
        End Function

        Private Shared ReadOnly smThailand As CountryData = InitializeThailand()
        Private Shared ReadOnly smThailandCountryCodes As String() = {"+66"}
        Private Shared ReadOnly smThailandIdds As String() = {"001"}
        Private Shared ReadOnly smThailandNdds As String() = {"0"}
        Private Shared Function InitializeThailand() As CountryData
            Dim country As New CountryData( _
             "Thailand", "TH", "TH", "THA", "764", "th", _
             smThailandCountryCodes, _
             smThailandIdds, _
             smThailandNdds)
            Return country
        End Function

        Private Shared ReadOnly smTogo As CountryData = InitializeTogo()
        Private Shared ReadOnly smTogoCountryCodes As String() = {"+228"}
        Private Shared ReadOnly smTogoIdds As String() = {"00"}
        Private Shared ReadOnly smTogoNdds As String() = {}
        Private Shared Function InitializeTogo() As CountryData
            Dim country As New CountryData( _
             "Togo", "TO", "TG", "TGO", "768", "tg", _
             smTogoCountryCodes, _
             smTogoIdds, _
             smTogoNdds)
            Return country
        End Function

        Private Shared ReadOnly smTokelau As CountryData = InitializeTokelau()
        Private Shared ReadOnly smTokelauCountryCodes As String() = {"+690"}
        Private Shared ReadOnly smTokelauIdds As String() = {"00"}
        Private Shared ReadOnly smTokelauNdds As String() = {}
        Private Shared Function InitializeTokelau() As CountryData
            Dim country As New CountryData( _
             "Tokelau", "TL", "TK", "TKL", "772", "tk", _
             smTokelauCountryCodes, _
             smTokelauIdds, _
             smTokelauNdds)
            Return country
        End Function

        Private Shared ReadOnly smTonga As CountryData = InitializeTonga()
        Private Shared ReadOnly smTongaCountryCodes As String() = {"+676"}
        Private Shared ReadOnly smTongaIdds As String() = {"00"}
        Private Shared ReadOnly smTongaNdds As String() = {}
        Private Shared Function InitializeTonga() As CountryData
            Dim country As New CountryData( _
             "Tonga", "TN", "TO", "TON", "776", "to", _
             smTongaCountryCodes, _
             smTongaIdds, _
             smTongaNdds)
            Return country
        End Function

        Private Shared ReadOnly smTrinidadTobago As CountryData = InitializeTrinidadTobago()
        Private Shared ReadOnly smTrinidadTobagoCountryCodes As String() = {"+1-868"}
        Private Shared ReadOnly smTrinidadTobagoIdds As String() = {"011"}
        Private Shared ReadOnly smTrinidadTobagoNdds As String() = {"1"}
        Private Shared Function InitializeTrinidadTobago() As CountryData
            Dim country As New CountryData( _
             "TrinidadTobago", "TD", "TT", "TTO", "780", "tt", _
             smTrinidadTobagoCountryCodes, _
             smTrinidadTobagoIdds, _
             smTrinidadTobagoNdds)
            Return country
        End Function

        Private Shared ReadOnly smTunisia As CountryData = InitializeTunisia()
        Private Shared ReadOnly smTunisiaCountryCodes As String() = {"+216"}
        Private Shared ReadOnly smTunisiaIdds As String() = {"00"}
        Private Shared ReadOnly smTunisiaNdds As String() = {"0"}
        Private Shared Function InitializeTunisia() As CountryData
            Dim country As New CountryData( _
             "Tunisia", "TS", "TN", "TUN", "788", "tn", _
             smTunisiaCountryCodes, _
             smTunisiaIdds, _
             smTunisiaNdds)
            Return country
        End Function

        Private Shared ReadOnly smTurkey As CountryData = InitializeTurkey()
        Private Shared ReadOnly smTurkeyCountryCodes As String() = {"+90"}
        Private Shared ReadOnly smTurkeyIdds As String() = {"00"}
        Private Shared ReadOnly smTurkeyNdds As String() = {"0"}
        Private Shared Function InitializeTurkey() As CountryData
            Dim country As New CountryData( _
             "Turkey", "TU", "TR", "TUR", "792", "tr", _
             smTurkeyCountryCodes, _
             smTurkeyIdds, _
             smTurkeyNdds)
            Return country
        End Function

        Private Shared ReadOnly smTurkmenistan As CountryData = InitializeTurkmenistan()
        Private Shared ReadOnly smTurkmenistanCountryCodes As String() = {"+944"}
        Private Shared ReadOnly smTurkmenistanIdds As String() = {"8~10"}
        Private Shared ReadOnly smTurkmenistanNdds As String() = {"8"}
        Private Shared Function InitializeTurkmenistan() As CountryData
            Dim country As New CountryData( _
             "Turkmenistan", "TX", "TM", "TKM", "795", "tm", _
             smTurkmenistanCountryCodes, _
             smTurkmenistanIdds, _
             smTurkmenistanNdds)
            Return country
        End Function

        Private Shared ReadOnly smTurksCaicosIslands As CountryData = InitializeTurksCaicosIslands()
        Private Shared ReadOnly smTurksCaicosIslandsCountryCodes As String() = {"+1-649"}
        Private Shared ReadOnly smTurksCaicosIslandsIdds As String() = {"011"}
        Private Shared ReadOnly smTurksCaicosIslandsNdds As String() = {"1"}
        Private Shared Function InitializeTurksCaicosIslands() As CountryData
            Dim country As New CountryData( _
             "TurksCaicosIslands", "TK", "TC", "TCA", "796", "tc", _
             smTurksCaicosIslandsCountryCodes, _
             smTurksCaicosIslandsIdds, _
             smTurksCaicosIslandsNdds)
            Return country
        End Function

        Private Shared ReadOnly smTuvalu As CountryData = InitializeTuvalu()
        Private Shared ReadOnly smTuvaluCountryCodes As String() = {"+688"}
        Private Shared ReadOnly smTuvaluIdds As String() = {"00"}
        Private Shared ReadOnly smTuvaluNdds As String() = {}
        Private Shared Function InitializeTuvalu() As CountryData
            Dim country As New CountryData( _
             "Tuvalu", "TV", "TV", "TUV", "798", "tv", _
             smTuvaluCountryCodes, _
             smTuvaluIdds, _
             smTuvaluNdds)
            Return country
        End Function

        Private Shared ReadOnly smUganda As CountryData = InitializeUganda()
        Private Shared ReadOnly smUgandaCountryCodes As String() = {"+256"}
        Private Shared ReadOnly smUgandaIdds As String() = {"000", "005", "007"}
        Private Shared ReadOnly smUgandaNdds As String() = {"0"}
        Private Shared Function InitializeUganda() As CountryData
            Dim country As New CountryData( _
             "Uganda", "UG", "UG", "UGA", "800", "ug", _
             smUgandaCountryCodes, _
             smUgandaIdds, _
             smUgandaNdds)
            Return country
        End Function

        Private Shared ReadOnly smUkraine As CountryData = InitializeUkraine()
        Private Shared ReadOnly smUkraineCountryCodes As String() = {"+380"}
        Private Shared ReadOnly smUkraineIdds As String() = {"8~10"}
        Private Shared ReadOnly smUkraineNdds As String() = {"8"}
        Private Shared Function InitializeUkraine() As CountryData
            Dim country As New CountryData( _
             "Ukraine", "UP", "UA", "UKR", "804", "ua", _
             smUkraineCountryCodes, _
             smUkraineIdds, _
             smUkraineNdds)
            Return country
        End Function

        Private Shared ReadOnly smUnitedArabEmirates As CountryData = InitializeUnitedArabEmirates()
        Private Shared ReadOnly smUnitedArabEmiratesCountryCodes As String() = {"+971"}
        Private Shared ReadOnly smUnitedArabEmiratesIdds As String() = {"00"}
        Private Shared ReadOnly smUnitedArabEmiratesNdds As String() = {}
        Private Shared Function InitializeUnitedArabEmirates() As CountryData
            Dim country As New CountryData( _
             "UnitedArabEmirates", "AE", "AE", "ARE", "784", "ae", _
             smUnitedArabEmiratesCountryCodes, _
             smUnitedArabEmiratesIdds, _
             smUnitedArabEmiratesNdds)
            Return country
        End Function

        Private Shared ReadOnly smUnitedKingdom As CountryData = InitializeUnitedKingdom()
        Private Shared ReadOnly smUnitedKingdomCountryCodes As String() = {"+44"}
        Private Shared ReadOnly smUnitedKingdomIdds As String() = {"00"}
        Private Shared ReadOnly smUnitedKingdomNdds As String() = {"0"}
        Private Shared Function InitializeUnitedKingdom() As CountryData
            Dim country As New CountryData( _
             "UnitedKingdom", "UK", "GB", "GBR", "826", "uk", _
             smUnitedKingdomCountryCodes, _
             smUnitedKingdomIdds, _
             smUnitedKingdomNdds)
            Return country
        End Function

        Private Shared ReadOnly smUnitedStates As CountryData = InitializeUnitedStates()
        Private Shared ReadOnly smUnitedStatesCountryCodes As String() = {"+1"}
        Private Shared ReadOnly smUnitedStatesIdds As String() = {"011"}
        Private Shared ReadOnly smUnitedStatesNdds As String() = {"1"}
        Private Shared Function InitializeUnitedStates() As CountryData
            Dim country As New CountryData( _
             "UnitedStates", "US", "US", "USA", "840", "us", _
             smUnitedStatesCountryCodes, _
             smUnitedStatesIdds, _
             smUnitedStatesNdds)
            Return country
        End Function

        Private Shared ReadOnly smUruguay As CountryData = InitializeUruguay()
        Private Shared ReadOnly smUruguayCountryCodes As String() = {"+598"}
        Private Shared ReadOnly smUruguayIdds As String() = {"00"}
        Private Shared ReadOnly smUruguayNdds As String() = {"0"}
        Private Shared Function InitializeUruguay() As CountryData
            Dim country As New CountryData( _
             "Uruguay", "UY", "UY", "URY", "858", "uy", _
             smUruguayCountryCodes, _
             smUruguayIdds, _
             smUruguayNdds)
            Return country
        End Function

        Private Shared ReadOnly smUzbekistan As CountryData = InitializeUzbekistan()
        Private Shared ReadOnly smUzbekistanCountryCodes As String() = {"+998"}
        Private Shared ReadOnly smUzbekistanIdds As String() = {"8~10"}
        Private Shared ReadOnly smUzbekistanNdds As String() = {"8"}
        Private Shared Function InitializeUzbekistan() As CountryData
            Dim country As New CountryData( _
             "Uzbekistan", "UZ", "UZ", "UZB", "860", "uz", _
             smUzbekistanCountryCodes, _
             smUzbekistanIdds, _
             smUzbekistanNdds)
            Return country
        End Function

        Private Shared ReadOnly smVanuatu As CountryData = InitializeVanuatu()
        Private Shared ReadOnly smVanuatuCountryCodes As String() = {"+678"}
        Private Shared ReadOnly smVanuatuIdds As String() = {"00"}
        Private Shared ReadOnly smVanuatuNdds As String() = {}
        Private Shared Function InitializeVanuatu() As CountryData
            Dim country As New CountryData( _
             "Vanuatu", "NH", "VU", "VUT", "548", "vu", _
             smVanuatuCountryCodes, _
             smVanuatuIdds, _
             smVanuatuNdds)
            Return country
        End Function

        Private Shared ReadOnly smVenezuela As CountryData = InitializeVenezuela()
        Private Shared ReadOnly smVenezuelaCountryCodes As String() = {"+58"}
        Private Shared ReadOnly smVenezuelaIdds As String() = {"00", "01-02-0", "01-07-0", "01-10-0", "01-11-0"}
        Private Shared ReadOnly smVenezuelaNdds As String() = {""}
        Private Shared Function InitializeVenezuela() As CountryData
            Dim country As New CountryData( _
             "Venezuela", "VE", "VE", "VEN", "862", "ve", _
             smVenezuelaCountryCodes, _
             smVenezuelaIdds, _
             smVenezuelaNdds)
            Return country
        End Function

        Private Shared ReadOnly smVietnam As CountryData = InitializeVietnam()
        Private Shared ReadOnly smVietnamCountryCodes As String() = {"+84"}
        Private Shared ReadOnly smVietnamIdds As String() = {"00"}
        Private Shared ReadOnly smVietnamNdds As String() = {"0"}
        Private Shared Function InitializeVietnam() As CountryData
            Dim country As New CountryData( _
             "Vietnam", "VM", "VN", "VNM", "704", "vn", _
             smVietnamCountryCodes, _
             smVietnamIdds, _
             smVietnamNdds)
            Return country
        End Function

        Private Shared ReadOnly smVirginIslands As CountryData = InitializeVirginIslands()
        Private Shared ReadOnly smVirginIslandsCountryCodes As String() = {"+1-340"}
        Private Shared ReadOnly smVirginIslandsIdds As String() = {"011"}
        Private Shared ReadOnly smVirginIslandsNdds As String() = {"1"}
        Private Shared Function InitializeVirginIslands() As CountryData
            Dim country As New CountryData( _
             "VirginIslands", "VQ", "VI", "VIR", "850", "vi", _
             smVirginIslandsCountryCodes, _
             smVirginIslandsIdds, _
             smVirginIslandsNdds)
            Return country
        End Function

        Private Shared ReadOnly smWallisFutuna As CountryData = InitializeWallisFutuna()
        Private Shared ReadOnly smWallisFutunaCountryCodes As String() = {"+681"}
        Private Shared ReadOnly smWallisFutunaIdds As String() = {"19"}
        Private Shared ReadOnly smWallisFutunaNdds As String() = {}
        Private Shared Function InitializeWallisFutuna() As CountryData
            Dim country As New CountryData( _
             "WallisFutuna", "WF", "WF", "WLF", "876", "wf", _
             smWallisFutunaCountryCodes, _
             smWallisFutunaIdds, _
             smWallisFutunaNdds)
            Return country
        End Function

        Private Shared ReadOnly smWestBank As CountryData = InitializeWestBank()
        Private Shared ReadOnly smWestBankCountryCodes As String() = {}
        Private Shared ReadOnly smWestBankIdds As String() = {}
        Private Shared ReadOnly smWestBankNdds As String() = {}
        Private Shared Function InitializeWestBank() As CountryData
            Dim country As New CountryData( _
             "WestBank", "WE", "PS", "PSE", "275", "ps", _
             smWestBankCountryCodes, _
             smWestBankIdds, _
             smWestBankNdds)
            Return country
        End Function

        Private Shared ReadOnly smWesternSahara As CountryData = InitializeWesternSahara()
        Private Shared ReadOnly smWesternSaharaCountryCodes As String() = {}
        Private Shared ReadOnly smWesternSaharaIdds As String() = {}
        Private Shared ReadOnly smWesternSaharaNdds As String() = {}
        Private Shared Function InitializeWesternSahara() As CountryData
            Dim country As New CountryData( _
             "WesternSahara", "WI", "EH", "ESH", "732", "eh", _
             smWesternSaharaCountryCodes, _
             smWesternSaharaIdds, _
             smWesternSaharaNdds)
            Return country
        End Function

        Private Shared ReadOnly smYemen As CountryData = InitializeYemen()
        Private Shared ReadOnly smYemenCountryCodes As String() = {"+967"}
        Private Shared ReadOnly smYemenIdds As String() = {"00"}
        Private Shared ReadOnly smYemenNdds As String() = {"0"}
        Private Shared Function InitializeYemen() As CountryData
            Dim country As New CountryData( _
             "Yemen", "YM", "YE", "YEM", "887", "ye", _
             smYemenCountryCodes, _
             smYemenIdds, _
             smYemenNdds)
            Return country
        End Function

        Private Shared ReadOnly smZambia As CountryData = InitializeZambia()
        Private Shared ReadOnly smZambiaCountryCodes As String() = {"+260"}
        Private Shared ReadOnly smZambiaIdds As String() = {"00"}
        Private Shared ReadOnly smZambiaNdds As String() = {"0"}
        Private Shared Function InitializeZambia() As CountryData
            Dim country As New CountryData( _
             "Zambia", "ZA", "ZM", "ZMB", "894", "zm", _
             smZambiaCountryCodes, _
             smZambiaIdds, _
             smZambiaNdds)
            Return country
        End Function

        Private Shared ReadOnly smZimbabwe As CountryData = InitializeZimbabwe()
        Private Shared ReadOnly smZimbabweCountryCodes As String() = {"+263"}
        Private Shared ReadOnly smZimbabweIdds As String() = {"00"}
        Private Shared ReadOnly smZimbabweNdds As String() = {"0"}
        Private Shared Function InitializeZimbabwe() As CountryData
            Dim country As New CountryData( _
             "Zimbabwe", "ZI", "ZW", "ZWE", "716", "zw", _
             smZimbabweCountryCodes, _
             smZimbabweIdds, _
             smZimbabweNdds)
            Return country
        End Function


        Public Shared ReadOnly Property Afghanistan() As CountryData
            Get
                Return smAfghanistan
            End Get
        End Property
        Public Shared ReadOnly Property Albania() As CountryData
            Get
                Return smAlbania
            End Get
        End Property
        Public Shared ReadOnly Property Algeria() As CountryData
            Get
                Return smAlgeria
            End Get
        End Property
        Public Shared ReadOnly Property AmericanSamoa() As CountryData
            Get
                Return smAmericanSamoa
            End Get
        End Property
        Public Shared ReadOnly Property Andorra() As CountryData
            Get
                Return smAndorra
            End Get
        End Property
        Public Shared ReadOnly Property Angola() As CountryData
            Get
                Return smAngola
            End Get
        End Property
        Public Shared ReadOnly Property Anguilla() As CountryData
            Get
                Return smAnguilla
            End Get
        End Property
        Public Shared ReadOnly Property Antarctica() As CountryData
            Get
                Return smAntarctica
            End Get
        End Property
        Public Shared ReadOnly Property AntiguaBarbuda() As CountryData
            Get
                Return smAntiguaBarbuda
            End Get
        End Property
        Public Shared ReadOnly Property Argentina() As CountryData
            Get
                Return smArgentina
            End Get
        End Property
        Public Shared ReadOnly Property Armenia() As CountryData
            Get
                Return smArmenia
            End Get
        End Property
        Public Shared ReadOnly Property Aruba() As CountryData
            Get
                Return smAruba
            End Get
        End Property
        Public Shared ReadOnly Property Australia() As CountryData
            Get
                Return smAustralia
            End Get
        End Property
        Public Shared ReadOnly Property Austria() As CountryData
            Get
                Return smAustria
            End Get
        End Property
        Public Shared ReadOnly Property Azerbaijan() As CountryData
            Get
                Return smAzerbaijan
            End Get
        End Property
        Public Shared ReadOnly Property Bahamas() As CountryData
            Get
                Return smBahamas
            End Get
        End Property
        Public Shared ReadOnly Property Bahrain() As CountryData
            Get
                Return smBahrain
            End Get
        End Property
        Public Shared ReadOnly Property Bangladesh() As CountryData
            Get
                Return smBangladesh
            End Get
        End Property
        Public Shared ReadOnly Property Barbados() As CountryData
            Get
                Return smBarbados
            End Get
        End Property
        Public Shared ReadOnly Property Belarus() As CountryData
            Get
                Return smBelarus
            End Get
        End Property
        Public Shared ReadOnly Property Belgium() As CountryData
            Get
                Return smBelgium
            End Get
        End Property
        Public Shared ReadOnly Property Belize() As CountryData
            Get
                Return smBelize
            End Get
        End Property
        Public Shared ReadOnly Property Benin() As CountryData
            Get
                Return smBenin
            End Get
        End Property
        Public Shared ReadOnly Property Bermuda() As CountryData
            Get
                Return smBermuda
            End Get
        End Property
        Public Shared ReadOnly Property Bhutan() As CountryData
            Get
                Return smBhutan
            End Get
        End Property
        Public Shared ReadOnly Property Bolivia() As CountryData
            Get
                Return smBolivia
            End Get
        End Property
        Public Shared ReadOnly Property BosniaHerzegovina() As CountryData
            Get
                Return smBosniaHerzegovina
            End Get
        End Property
        Public Shared ReadOnly Property Botswana() As CountryData
            Get
                Return smBotswana
            End Get
        End Property
        Public Shared ReadOnly Property BouvetIsland() As CountryData
            Get
                Return smBouvetIsland
            End Get
        End Property
        Public Shared ReadOnly Property Brazil() As CountryData
            Get
                Return smBrazil
            End Get
        End Property
        Public Shared ReadOnly Property BritishIndianOceanTerritory() As CountryData
            Get
                Return smBritishIndianOceanTerritory
            End Get
        End Property
        Public Shared ReadOnly Property BritishVirginIslands() As CountryData
            Get
                Return smBritishVirginIslands
            End Get
        End Property
        Public Shared ReadOnly Property Brunei() As CountryData
            Get
                Return smBrunei
            End Get
        End Property
        Public Shared ReadOnly Property Bulgaria() As CountryData
            Get
                Return smBulgaria
            End Get
        End Property
        Public Shared ReadOnly Property BurkinaFaso() As CountryData
            Get
                Return smBurkinaFaso
            End Get
        End Property
        Public Shared ReadOnly Property Burma() As CountryData
            Get
                Return smBurma
            End Get
        End Property
        Public Shared ReadOnly Property Burundi() As CountryData
            Get
                Return smBurundi
            End Get
        End Property
        Public Shared ReadOnly Property Cambodia() As CountryData
            Get
                Return smCambodia
            End Get
        End Property
        Public Shared ReadOnly Property Cameroon() As CountryData
            Get
                Return smCameroon
            End Get
        End Property
        Public Shared ReadOnly Property Canada() As CountryData
            Get
                Return smCanada
            End Get
        End Property
        Public Shared ReadOnly Property CapeVerde() As CountryData
            Get
                Return smCapeVerde
            End Get
        End Property
        Public Shared ReadOnly Property CaymanIslands() As CountryData
            Get
                Return smCaymanIslands
            End Get
        End Property
        Public Shared ReadOnly Property CentralAfricanRepublic() As CountryData
            Get
                Return smCentralAfricanRepublic
            End Get
        End Property
        Public Shared ReadOnly Property Chad() As CountryData
            Get
                Return smChad
            End Get
        End Property
        Public Shared ReadOnly Property Chile() As CountryData
            Get
                Return smChile
            End Get
        End Property
        Public Shared ReadOnly Property China() As CountryData
            Get
                Return smChina
            End Get
        End Property
        Public Shared ReadOnly Property ChristmasIsland() As CountryData
            Get
                Return smChristmasIsland
            End Get
        End Property
        Public Shared ReadOnly Property CocosKeelingIslands() As CountryData
            Get
                Return smCocosKeelingIslands
            End Get
        End Property
        Public Shared ReadOnly Property Colombia() As CountryData
            Get
                Return smColombia
            End Get
        End Property
        Public Shared ReadOnly Property Comoros() As CountryData
            Get
                Return smComoros
            End Get
        End Property
        Public Shared ReadOnly Property CongoDemocraticRepublic() As CountryData
            Get
                Return smCongoDemocraticRepublic
            End Get
        End Property
        Public Shared ReadOnly Property CongoRepublic() As CountryData
            Get
                Return smCongoRepublic
            End Get
        End Property
        Public Shared ReadOnly Property CookIslands() As CountryData
            Get
                Return smCookIslands
            End Get
        End Property
        Public Shared ReadOnly Property CostaRica() As CountryData
            Get
                Return smCostaRica
            End Get
        End Property
        Public Shared ReadOnly Property CoteDIvoire() As CountryData
            Get
                Return smCoteDIvoire
            End Get
        End Property
        Public Shared ReadOnly Property Croatia() As CountryData
            Get
                Return smCroatia
            End Get
        End Property
        Public Shared ReadOnly Property Cuba() As CountryData
            Get
                Return smCuba
            End Get
        End Property
        Public Shared ReadOnly Property Cyprus() As CountryData
            Get
                Return smCyprus
            End Get
        End Property
        Public Shared ReadOnly Property CzechRepublic() As CountryData
            Get
                Return smCzechRepublic
            End Get
        End Property
        Public Shared ReadOnly Property Denmark() As CountryData
            Get
                Return smDenmark
            End Get
        End Property
        Public Shared ReadOnly Property Djibouti() As CountryData
            Get
                Return smDjibouti
            End Get
        End Property
        Public Shared ReadOnly Property Dominica() As CountryData
            Get
                Return smDominica
            End Get
        End Property
        Public Shared ReadOnly Property DominicanRepublic() As CountryData
            Get
                Return smDominicanRepublic
            End Get
        End Property
        Public Shared ReadOnly Property EastTimor() As CountryData
            Get
                Return smEastTimor
            End Get
        End Property
        Public Shared ReadOnly Property Ecuador() As CountryData
            Get
                Return smEcuador
            End Get
        End Property
        Public Shared ReadOnly Property Egypt() As CountryData
            Get
                Return smEgypt
            End Get
        End Property
        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1706:ShortAcronymsShouldBeUppercase", MessageId:="Member")> Public Shared ReadOnly Property ElSalvador() As CountryData
            Get
                Return smElSalvador
            End Get
        End Property
        Public Shared ReadOnly Property EquatorialGuinea() As CountryData
            Get
                Return smEquatorialGuinea
            End Get
        End Property
        Public Shared ReadOnly Property Eritrea() As CountryData
            Get
                Return smEritrea
            End Get
        End Property
        Public Shared ReadOnly Property Estonia() As CountryData
            Get
                Return smEstonia
            End Get
        End Property
        Public Shared ReadOnly Property Ethiopia() As CountryData
            Get
                Return smEthiopia
            End Get
        End Property
        Public Shared ReadOnly Property FalklandIslandsIslasMalvinas() As CountryData
            Get
                Return smFalklandIslandsIslasMalvinas
            End Get
        End Property
        Public Shared ReadOnly Property FaroeIslands() As CountryData
            Get
                Return smFaroeIslands
            End Get
        End Property
        Public Shared ReadOnly Property Fiji() As CountryData
            Get
                Return smFiji
            End Get
        End Property
        Public Shared ReadOnly Property Finland() As CountryData
            Get
                Return smFinland
            End Get
        End Property
        Public Shared ReadOnly Property France() As CountryData
            Get
                Return smFrance
            End Get
        End Property
        Public Shared ReadOnly Property FrenchGuiana() As CountryData
            Get
                Return smFrenchGuiana
            End Get
        End Property
        Public Shared ReadOnly Property FrenchPolynesia() As CountryData
            Get
                Return smFrenchPolynesia
            End Get
        End Property
        Public Shared ReadOnly Property FrenchSouthernAntarcticLands() As CountryData
            Get
                Return smFrenchSouthernAntarcticLands
            End Get
        End Property
        Public Shared ReadOnly Property Gabon() As CountryData
            Get
                Return smGabon
            End Get
        End Property
        Public Shared ReadOnly Property Gambia() As CountryData
            Get
                Return smGambia
            End Get
        End Property
        Public Shared ReadOnly Property GazaStrip() As CountryData
            Get
                Return smGazaStrip
            End Get
        End Property
        Public Shared ReadOnly Property Georgia() As CountryData
            Get
                Return smGeorgia
            End Get
        End Property
        Public Shared ReadOnly Property Germany() As CountryData
            Get
                Return smGermany
            End Get
        End Property
        Public Shared ReadOnly Property Ghana() As CountryData
            Get
                Return smGhana
            End Get
        End Property
        Public Shared ReadOnly Property Gibraltar() As CountryData
            Get
                Return smGibraltar
            End Get
        End Property
        Public Shared ReadOnly Property Greece() As CountryData
            Get
                Return smGreece
            End Get
        End Property
        Public Shared ReadOnly Property Greenland() As CountryData
            Get
                Return smGreenland
            End Get
        End Property
        Public Shared ReadOnly Property Grenada() As CountryData
            Get
                Return smGrenada
            End Get
        End Property
        Public Shared ReadOnly Property Guadeloupe() As CountryData
            Get
                Return smGuadeloupe
            End Get
        End Property
        Public Shared ReadOnly Property Guam() As CountryData
            Get
                Return smGuam
            End Get
        End Property
        Public Shared ReadOnly Property Guatemala() As CountryData
            Get
                Return smGuatemala
            End Get
        End Property
        Public Shared ReadOnly Property Guinea() As CountryData
            Get
                Return smGuinea
            End Get
        End Property
        Public Shared ReadOnly Property GuineaBissau() As CountryData
            Get
                Return smGuineaBissau
            End Get
        End Property
        Public Shared ReadOnly Property Guyana() As CountryData
            Get
                Return smGuyana
            End Get
        End Property
        Public Shared ReadOnly Property Haiti() As CountryData
            Get
                Return smHaiti
            End Get
        End Property
        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1706:ShortAcronymsShouldBeUppercase", MessageId:="Member")> Public Shared ReadOnly Property HeardIslandMcDonaldIslands() As CountryData
            Get
                Return smHeardIslandMcDonaldIslands
            End Get
        End Property
        Public Shared ReadOnly Property HolySeeVaticanCity() As CountryData
            Get
                Return smHolySeeVaticanCity
            End Get
        End Property
        Public Shared ReadOnly Property Honduras() As CountryData
            Get
                Return smHonduras
            End Get
        End Property
        Public Shared ReadOnly Property HongKong() As CountryData
            Get
                Return smHongKong
            End Get
        End Property
        Public Shared ReadOnly Property Hungary() As CountryData
            Get
                Return smHungary
            End Get
        End Property
        Public Shared ReadOnly Property Iceland() As CountryData
            Get
                Return smIceland
            End Get
        End Property
        Public Shared ReadOnly Property India() As CountryData
            Get
                Return smIndia
            End Get
        End Property
        Public Shared ReadOnly Property Indonesia() As CountryData
            Get
                Return smIndonesia
            End Get
        End Property
        Public Shared ReadOnly Property Iran() As CountryData
            Get
                Return smIran
            End Get
        End Property
        Public Shared ReadOnly Property Iraq() As CountryData
            Get
                Return smIraq
            End Get
        End Property
        Public Shared ReadOnly Property Ireland() As CountryData
            Get
                Return smIreland
            End Get
        End Property
        Public Shared ReadOnly Property Israel() As CountryData
            Get
                Return smIsrael
            End Get
        End Property
        Public Shared ReadOnly Property Italy() As CountryData
            Get
                Return smItaly
            End Get
        End Property
        Public Shared ReadOnly Property Jamaica() As CountryData
            Get
                Return smJamaica
            End Get
        End Property
        Public Shared ReadOnly Property Japan() As CountryData
            Get
                Return smJapan
            End Get
        End Property
        Public Shared ReadOnly Property Jordan() As CountryData
            Get
                Return smJordan
            End Get
        End Property
        Public Shared ReadOnly Property Kazakhstan() As CountryData
            Get
                Return smKazakhstan
            End Get
        End Property
        Public Shared ReadOnly Property Kenya() As CountryData
            Get
                Return smKenya
            End Get
        End Property
        Public Shared ReadOnly Property Kiribati() As CountryData
            Get
                Return smKiribati
            End Get
        End Property
        Public Shared ReadOnly Property KoreaNorth() As CountryData
            Get
                Return smKoreaNorth
            End Get
        End Property
        Public Shared ReadOnly Property KoreaSouth() As CountryData
            Get
                Return smKoreaSouth
            End Get
        End Property
        Public Shared ReadOnly Property Kuwait() As CountryData
            Get
                Return smKuwait
            End Get
        End Property
        Public Shared ReadOnly Property Kyrgyzstan() As CountryData
            Get
                Return smKyrgyzstan
            End Get
        End Property
        Public Shared ReadOnly Property Laos() As CountryData
            Get
                Return smLaos
            End Get
        End Property
        Public Shared ReadOnly Property Latvia() As CountryData
            Get
                Return smLatvia
            End Get
        End Property
        Public Shared ReadOnly Property Lebanon() As CountryData
            Get
                Return smLebanon
            End Get
        End Property
        Public Shared ReadOnly Property Lesotho() As CountryData
            Get
                Return smLesotho
            End Get
        End Property
        Public Shared ReadOnly Property Liberia() As CountryData
            Get
                Return smLiberia
            End Get
        End Property
        Public Shared ReadOnly Property Libya() As CountryData
            Get
                Return smLibya
            End Get
        End Property
        Public Shared ReadOnly Property Liechtenstein() As CountryData
            Get
                Return smLiechtenstein
            End Get
        End Property
        Public Shared ReadOnly Property Lithuania() As CountryData
            Get
                Return smLithuania
            End Get
        End Property
        Public Shared ReadOnly Property Luxembourg() As CountryData
            Get
                Return smLuxembourg
            End Get
        End Property
        Public Shared ReadOnly Property Macau() As CountryData
            Get
                Return smMacau
            End Get
        End Property
        Public Shared ReadOnly Property Macedonia() As CountryData
            Get
                Return smMacedonia
            End Get
        End Property
        Public Shared ReadOnly Property Madagascar() As CountryData
            Get
                Return smMadagascar
            End Get
        End Property
        Public Shared ReadOnly Property Malawi() As CountryData
            Get
                Return smMalawi
            End Get
        End Property
        Public Shared ReadOnly Property Malaysia() As CountryData
            Get
                Return smMalaysia
            End Get
        End Property
        Public Shared ReadOnly Property Maldives() As CountryData
            Get
                Return smMaldives
            End Get
        End Property
        Public Shared ReadOnly Property Mali() As CountryData
            Get
                Return smMali
            End Get
        End Property
        Public Shared ReadOnly Property Malta() As CountryData
            Get
                Return smMalta
            End Get
        End Property
        Public Shared ReadOnly Property MarshallIslands() As CountryData
            Get
                Return smMarshallIslands
            End Get
        End Property
        Public Shared ReadOnly Property Martinique() As CountryData
            Get
                Return smMartinique
            End Get
        End Property
        Public Shared ReadOnly Property Mauritania() As CountryData
            Get
                Return smMauritania
            End Get
        End Property
        Public Shared ReadOnly Property Mauritius() As CountryData
            Get
                Return smMauritius
            End Get
        End Property
        Public Shared ReadOnly Property Mayotte() As CountryData
            Get
                Return smMayotte
            End Get
        End Property
        Public Shared ReadOnly Property Mexico() As CountryData
            Get
                Return smMexico
            End Get
        End Property
        Public Shared ReadOnly Property Micronesia() As CountryData
            Get
                Return smMicronesia
            End Get
        End Property
        Public Shared ReadOnly Property Moldova() As CountryData
            Get
                Return smMoldova
            End Get
        End Property
        Public Shared ReadOnly Property Monaco() As CountryData
            Get
                Return smMonaco
            End Get
        End Property
        Public Shared ReadOnly Property Mongolia() As CountryData
            Get
                Return smMongolia
            End Get
        End Property
        Public Shared ReadOnly Property Montserrat() As CountryData
            Get
                Return smMontserrat
            End Get
        End Property
        Public Shared ReadOnly Property Morocco() As CountryData
            Get
                Return smMorocco
            End Get
        End Property
        Public Shared ReadOnly Property Mozambique() As CountryData
            Get
                Return smMozambique
            End Get
        End Property
        Public Shared ReadOnly Property Namibia() As CountryData
            Get
                Return smNamibia
            End Get
        End Property
        Public Shared ReadOnly Property Nauru() As CountryData
            Get
                Return smNauru
            End Get
        End Property
        Public Shared ReadOnly Property Nepal() As CountryData
            Get
                Return smNepal
            End Get
        End Property
        Public Shared ReadOnly Property Netherlands() As CountryData
            Get
                Return smNetherlands
            End Get
        End Property
        Public Shared ReadOnly Property NetherlandsAntilles() As CountryData
            Get
                Return smNetherlandsAntilles
            End Get
        End Property
        Public Shared ReadOnly Property NewCaledonia() As CountryData
            Get
                Return smNewCaledonia
            End Get
        End Property
        Public Shared ReadOnly Property NewZealand() As CountryData
            Get
                Return smNewZealand
            End Get
        End Property
        Public Shared ReadOnly Property Nicaragua() As CountryData
            Get
                Return smNicaragua
            End Get
        End Property
        Public Shared ReadOnly Property Niger() As CountryData
            Get
                Return smNiger
            End Get
        End Property
        Public Shared ReadOnly Property Nigeria() As CountryData
            Get
                Return smNigeria
            End Get
        End Property
        Public Shared ReadOnly Property Niue() As CountryData
            Get
                Return smNiue
            End Get
        End Property
        Public Shared ReadOnly Property NorfolkIsland() As CountryData
            Get
                Return smNorfolkIsland
            End Get
        End Property
        Public Shared ReadOnly Property NorthernMarianaIslands() As CountryData
            Get
                Return smNorthernMarianaIslands
            End Get
        End Property
        Public Shared ReadOnly Property Norway() As CountryData
            Get
                Return smNorway
            End Get
        End Property
        Public Shared ReadOnly Property Oman() As CountryData
            Get
                Return smOman
            End Get
        End Property
        Public Shared ReadOnly Property Pakistan() As CountryData
            Get
                Return smPakistan
            End Get
        End Property
        Public Shared ReadOnly Property Palau() As CountryData
            Get
                Return smPalau
            End Get
        End Property
        Public Shared ReadOnly Property Panama() As CountryData
            Get
                Return smPanama
            End Get
        End Property
        Public Shared ReadOnly Property PapuaNewGuinea() As CountryData
            Get
                Return smPapuaNewGuinea
            End Get
        End Property
        Public Shared ReadOnly Property Paraguay() As CountryData
            Get
                Return smParaguay
            End Get
        End Property
        Public Shared ReadOnly Property Peru() As CountryData
            Get
                Return smPeru
            End Get
        End Property
        Public Shared ReadOnly Property Philippines() As CountryData
            Get
                Return smPhilippines
            End Get
        End Property
        Public Shared ReadOnly Property PitcairnIslands() As CountryData
            Get
                Return smPitcairnIslands
            End Get
        End Property
        Public Shared ReadOnly Property Poland() As CountryData
            Get
                Return smPoland
            End Get
        End Property
        Public Shared ReadOnly Property Portugal() As CountryData
            Get
                Return smPortugal
            End Get
        End Property
        Public Shared ReadOnly Property PuertoRico() As CountryData
            Get
                Return smPuertoRico
            End Get
        End Property
        Public Shared ReadOnly Property Qatar() As CountryData
            Get
                Return smQatar
            End Get
        End Property
        Public Shared ReadOnly Property Reunion() As CountryData
            Get
                Return smReunion
            End Get
        End Property
        Public Shared ReadOnly Property Romania() As CountryData
            Get
                Return smRomania
            End Get
        End Property
        Public Shared ReadOnly Property Russia() As CountryData
            Get
                Return smRussia
            End Get
        End Property
        Public Shared ReadOnly Property Rwanda() As CountryData
            Get
                Return smRwanda
            End Get
        End Property
        Public Shared ReadOnly Property SaintHelena() As CountryData
            Get
                Return smSaintHelena
            End Get
        End Property
        Public Shared ReadOnly Property SaintKittsNevis() As CountryData
            Get
                Return smSaintKittsNevis
            End Get
        End Property
        Public Shared ReadOnly Property SaintLucia() As CountryData
            Get
                Return smSaintLucia
            End Get
        End Property
        Public Shared ReadOnly Property SaintPierreMiquelon() As CountryData
            Get
                Return smSaintPierreMiquelon
            End Get
        End Property
        Public Shared ReadOnly Property SaintVincentGrenadines() As CountryData
            Get
                Return smSaintVincentGrenadines
            End Get
        End Property
        Public Shared ReadOnly Property Samoa() As CountryData
            Get
                Return smSamoa
            End Get
        End Property
        Public Shared ReadOnly Property SanMarino() As CountryData
            Get
                Return smSanMarino
            End Get
        End Property
        Public Shared ReadOnly Property SaoTome() As CountryData
            Get
                Return smSaoTome
            End Get
        End Property
        Public Shared ReadOnly Property SaudiArabia() As CountryData
            Get
                Return smSaudiArabia
            End Get
        End Property
        Public Shared ReadOnly Property Senegal() As CountryData
            Get
                Return smSenegal
            End Get
        End Property
        Public Shared ReadOnly Property SerbiaMontenegro() As CountryData
            Get
                Return smSerbiaMontenegro
            End Get
        End Property
        Public Shared ReadOnly Property Seychelles() As CountryData
            Get
                Return smSeychelles
            End Get
        End Property
        Public Shared ReadOnly Property SierraLeone() As CountryData
            Get
                Return smSierraLeone
            End Get
        End Property
        Public Shared ReadOnly Property Singapore() As CountryData
            Get
                Return smSingapore
            End Get
        End Property
        Public Shared ReadOnly Property Slovakia() As CountryData
            Get
                Return smSlovakia
            End Get
        End Property
        Public Shared ReadOnly Property Slovenia() As CountryData
            Get
                Return smSlovenia
            End Get
        End Property
        Public Shared ReadOnly Property SolomonIslands() As CountryData
            Get
                Return smSolomonIslands
            End Get
        End Property
        Public Shared ReadOnly Property Somalia() As CountryData
            Get
                Return smSomalia
            End Get
        End Property
        Public Shared ReadOnly Property SouthAfrica() As CountryData
            Get
                Return smSouthAfrica
            End Get
        End Property
        Public Shared ReadOnly Property SouthGeorgiaIslands() As CountryData
            Get
                Return smSouthGeorgiaIslands
            End Get
        End Property
        Public Shared ReadOnly Property Spain() As CountryData
            Get
                Return smSpain
            End Get
        End Property
        Public Shared ReadOnly Property SriLanka() As CountryData
            Get
                Return smSriLanka
            End Get
        End Property
        Public Shared ReadOnly Property Sudan() As CountryData
            Get
                Return smSudan
            End Get
        End Property
        Public Shared ReadOnly Property Suriname() As CountryData
            Get
                Return smSuriname
            End Get
        End Property
        Public Shared ReadOnly Property Svalbard() As CountryData
            Get
                Return smSvalbard
            End Get
        End Property
        Public Shared ReadOnly Property Swaziland() As CountryData
            Get
                Return smSwaziland
            End Get
        End Property
        Public Shared ReadOnly Property Sweden() As CountryData
            Get
                Return smSweden
            End Get
        End Property
        Public Shared ReadOnly Property Switzerland() As CountryData
            Get
                Return smSwitzerland
            End Get
        End Property
        Public Shared ReadOnly Property Syria() As CountryData
            Get
                Return smSyria
            End Get
        End Property
        Public Shared ReadOnly Property Taiwan() As CountryData
            Get
                Return smTaiwan
            End Get
        End Property
        Public Shared ReadOnly Property Tajikistan() As CountryData
            Get
                Return smTajikistan
            End Get
        End Property
        Public Shared ReadOnly Property Tanzania() As CountryData
            Get
                Return smTanzania
            End Get
        End Property
        Public Shared ReadOnly Property Thailand() As CountryData
            Get
                Return smThailand
            End Get
        End Property
        Public Shared ReadOnly Property Togo() As CountryData
            Get
                Return smTogo
            End Get
        End Property
        Public Shared ReadOnly Property Tokelau() As CountryData
            Get
                Return smTokelau
            End Get
        End Property
        Public Shared ReadOnly Property Tonga() As CountryData
            Get
                Return smTonga
            End Get
        End Property
        Public Shared ReadOnly Property TrinidadTobago() As CountryData
            Get
                Return smTrinidadTobago
            End Get
        End Property
        Public Shared ReadOnly Property Tunisia() As CountryData
            Get
                Return smTunisia
            End Get
        End Property
        Public Shared ReadOnly Property Turkey() As CountryData
            Get
                Return smTurkey
            End Get
        End Property
        Public Shared ReadOnly Property Turkmenistan() As CountryData
            Get
                Return smTurkmenistan
            End Get
        End Property
        Public Shared ReadOnly Property TurksCaicosIslands() As CountryData
            Get
                Return smTurksCaicosIslands
            End Get
        End Property
        Public Shared ReadOnly Property Tuvalu() As CountryData
            Get
                Return smTuvalu
            End Get
        End Property
        Public Shared ReadOnly Property Uganda() As CountryData
            Get
                Return smUganda
            End Get
        End Property
        Public Shared ReadOnly Property Ukraine() As CountryData
            Get
                Return smUkraine
            End Get
        End Property
        Public Shared ReadOnly Property UnitedArabEmirates() As CountryData
            Get
                Return smUnitedArabEmirates
            End Get
        End Property
        Public Shared ReadOnly Property UnitedKingdom() As CountryData
            Get
                Return smUnitedKingdom
            End Get
        End Property
        Public Shared ReadOnly Property UnitedStates() As CountryData
            Get
                Return smUnitedStates
            End Get
        End Property
        Public Shared ReadOnly Property Uruguay() As CountryData
            Get
                Return smUruguay
            End Get
        End Property
        Public Shared ReadOnly Property Uzbekistan() As CountryData
            Get
                Return smUzbekistan
            End Get
        End Property
        Public Shared ReadOnly Property Vanuatu() As CountryData
            Get
                Return smVanuatu
            End Get
        End Property
        Public Shared ReadOnly Property Venezuela() As CountryData
            Get
                Return smVenezuela
            End Get
        End Property
        Public Shared ReadOnly Property Vietnam() As CountryData
            Get
                Return smVietnam
            End Get
        End Property
        Public Shared ReadOnly Property VirginIslands() As CountryData
            Get
                Return smVirginIslands
            End Get
        End Property
        Public Shared ReadOnly Property WallisFutuna() As CountryData
            Get
                Return smWallisFutuna
            End Get
        End Property
        Public Shared ReadOnly Property WestBank() As CountryData
            Get
                Return smWestBank
            End Get
        End Property
        Public Shared ReadOnly Property WesternSahara() As CountryData
            Get
                Return smWesternSahara
            End Get
        End Property
        Public Shared ReadOnly Property Yemen() As CountryData
            Get
                Return smYemen
            End Get
        End Property
        Public Shared ReadOnly Property Zambia() As CountryData
            Get
                Return smZambia
            End Get
        End Property
        Public Shared ReadOnly Property Zimbabwe() As CountryData
            Get
                Return smZimbabwe
            End Get
        End Property

        Private Shared smByFips104Alpha2 As Hashtable = InitializeFips104Alpha2()
        Private Shared Function InitializeFips104Alpha2() As Hashtable
            Dim table As New Hashtable
            For i As Integer = 0 To All.Length - 1
                table(All(i).Fips104Alpha2) = All(i)
            Next
            Return table
        End Function
        Private Shared smByIso3166Alpha2 As Hashtable = InitializeIso3166Alpha2()
        Private Shared Function InitializeIso3166Alpha2() As Hashtable
            Dim table As New Hashtable
            For i As Integer = 0 To All.Length - 1
                table(All(i).Iso3166Alpha2) = All(i)
            Next
            Return table
        End Function
        Private Shared smByIso3166Alpha3 As Hashtable = InitializeIso3166Alpha3()
        Private Shared Function InitializeIso3166Alpha3() As Hashtable
            Dim table As New Hashtable
            For i As Integer = 0 To All.Length - 1
                table(All(i).Iso3166Alpha3) = All(i)
            Next
            Return table
        End Function
        Private Shared smByIso3166Digit3 As Hashtable = InitializeIso3166Digit3()
        Private Shared Function InitializeIso3166Digit3() As Hashtable
            Dim table As New Hashtable
            For i As Integer = 0 To All.Length - 1
                table(All(i).Iso3166Digit3) = All(i)
            Next
            Return table
        End Function
        Private Shared smByInternetSuffix As Hashtable = InitializeInternetSuffix()
        Private Shared Function InitializeInternetSuffix() As Hashtable
            Dim table As New Hashtable
            For i As Integer = 0 To All.Length - 1
                table(All(i).InternetSuffix) = All(i)
            Next
            Return table
        End Function


        Private Shared smAllCountries() As CountryData = { _
        smAfghanistan, _
        smAlbania, _
        smAlgeria, _
        smAmericanSamoa, _
        smAndorra, _
        smAngola, _
        smAnguilla, _
        smAntarctica, _
        smAntiguaBarbuda, _
        smArgentina, _
        smArmenia, _
        smAruba, _
        smAustralia, _
        smAustria, _
        smAzerbaijan, _
        smBahamas, _
        smBahrain, _
        smBangladesh, _
        smBarbados, _
        smBelarus, _
        smBelgium, _
        smBelize, _
        smBenin, _
        smBermuda, _
        smBhutan, _
        smBolivia, _
        smBosniaHerzegovina, _
        smBotswana, _
        smBouvetIsland, _
        smBrazil, _
        smBritishIndianOceanTerritory, _
        smBritishVirginIslands, _
        smBrunei, _
        smBulgaria, _
        smBurkinaFaso, _
        smBurma, _
        smBurundi, _
        smCambodia, _
        smCameroon, _
        smCanada, _
        smCapeVerde, _
        smCaymanIslands, _
        smCentralAfricanRepublic, _
        smChad, _
        smChile, _
        smChina, _
        smChristmasIsland, _
        smCocosKeelingIslands, _
        smColombia, _
        smComoros, _
        smCongoDemocraticRepublic, _
        smCongoRepublic, _
        smCookIslands, _
        smCostaRica, _
        smCoteDIvoire, _
        smCroatia, _
        smCuba, _
        smCyprus, _
        smCzechRepublic, _
        smDenmark, _
        smDjibouti, _
        smDominica, _
        smDominicanRepublic, _
        smEastTimor, _
        smEcuador, _
        smEgypt, _
        smElSalvador, _
        smEquatorialGuinea, _
        smEritrea, _
        smEstonia, _
        smEthiopia, _
        smFalklandIslandsIslasMalvinas, _
        smFaroeIslands, _
        smFiji, _
        smFinland, _
        smFrance, _
        smFrenchGuiana, _
        smFrenchPolynesia, _
        smFrenchSouthernAntarcticLands, _
        smGabon, _
        smGambia, _
        smGazaStrip, _
        smGeorgia, _
        smGermany, _
        smGhana, _
        smGibraltar, _
        smGreece, _
        smGreenland, _
        smGrenada, _
        smGuadeloupe, _
        smGuam, _
        smGuatemala, _
        smGuinea, _
        smGuineaBissau, _
        smGuyana, _
        smHaiti, _
        smHeardIslandMcDonaldIslands, _
        smHolySeeVaticanCity, _
        smHonduras, _
        smHongKong, _
        smHungary, _
        smIceland, _
        smIndia, _
        smIndonesia, _
        smIran, _
        smIraq, _
        smIreland, _
        smIsrael, _
        smItaly, _
        smJamaica, _
        smJapan, _
        smJordan, _
        smKazakhstan, _
        smKenya, _
        smKiribati, _
        smKoreaNorth, _
        smKoreaSouth, _
        smKuwait, _
        smKyrgyzstan, _
        smLaos, _
        smLatvia, _
        smLebanon, _
        smLesotho, _
        smLiberia, _
        smLibya, _
        smLiechtenstein, _
        smLithuania, _
        smLuxembourg, _
        smMacau, _
        smMacedonia, _
        smMadagascar, _
        smMalawi, _
        smMalaysia, _
        smMaldives, _
        smMali, _
        smMalta, _
        smMarshallIslands, _
        smMartinique, _
        smMauritania, _
        smMauritius, _
        smMayotte, _
        smMexico, _
        smMicronesia, _
        smMoldova, _
        smMonaco, _
        smMongolia, _
        smMontserrat, _
        smMorocco, _
        smMozambique, _
        smNamibia, _
        smNauru, _
        smNepal, _
        smNetherlands, _
        smNetherlandsAntilles, _
        smNewCaledonia, _
        smNewZealand, _
        smNicaragua, _
        smNiger, _
        smNigeria, _
        smNiue, _
        smNorfolkIsland, _
        smNorthernMarianaIslands, _
        smNorway, _
        smOman, _
        smPakistan, _
        smPalau, _
        smPanama, _
        smPapuaNewGuinea, _
        smParaguay, _
        smPeru, _
        smPhilippines, _
        smPitcairnIslands, _
        smPoland, _
        smPortugal, _
        smPuertoRico, _
        smQatar, _
        smReunion, _
        smRomania, _
        smRussia, _
        smRwanda, _
        smSaintHelena, _
        smSaintKittsNevis, _
        smSaintLucia, _
        smSaintPierreMiquelon, _
        smSaintVincentGrenadines, _
        smSamoa, _
        smSanMarino, _
        smSaoTome, _
        smSaudiArabia, _
        smSenegal, _
        smSerbiaMontenegro, _
        smSeychelles, _
        smSierraLeone, _
        smSingapore, _
        smSlovakia, _
        smSlovenia, _
        smSolomonIslands, _
        smSomalia, _
        smSouthAfrica, _
        smSouthGeorgiaIslands, _
        smSpain, _
        smSriLanka, _
        smSudan, _
        smSuriname, _
        smSvalbard, _
        smSwaziland, _
        smSweden, _
        smSwitzerland, _
        smSyria, _
        smTaiwan, _
        smTajikistan, _
        smTanzania, _
        smThailand, _
        smTogo, _
        smTokelau, _
        smTonga, _
        smTrinidadTobago, _
        smTunisia, _
        smTurkey, _
        smTurkmenistan, _
        smTurksCaicosIslands, _
        smTuvalu, _
        smUganda, _
        smUkraine, _
        smUnitedArabEmirates, _
        smUnitedKingdom, _
        smUnitedStates, _
        smUruguay, _
        smUzbekistan, _
        smVanuatu, _
        smVenezuela, _
        smVietnam, _
        smVirginIslands, _
        smWallisFutuna, _
        smWestBank, _
        smWesternSahara, _
        smYemen, _
        smZambia, _
        smZimbabwe _
        }


        Private Shared ReadOnly Property All() As CountryData()
            Get
                Return smAllCountries
            End Get
        End Property

        Public Shared ReadOnly Property ByFips104Alpha2(ByVal code As String) As CountryData
            Get
                Return DirectCast(smByFips104Alpha2(code), CountryData)
            End Get
        End Property

        Public Shared ReadOnly Property ByIso3166Alpha2(ByVal code As String) As CountryData
            Get
                Return DirectCast(smByIso3166Alpha2(code), CountryData)
            End Get
        End Property

        Public Shared ReadOnly Property ByIso3166Alpha3(ByVal code As String) As CountryData
            Get
                Return DirectCast(smByIso3166Alpha3(code), CountryData)
            End Get
        End Property

        Public Shared ReadOnly Property ByIso3166Digit3(ByVal code As String) As CountryData
            Get
                Return DirectCast(smByIso3166Digit3(code), CountryData)
            End Get
        End Property

        Public Shared ReadOnly Property ByInternetSuffix(ByVal code As String) As CountryData
            Get
                Return DirectCast(smByInternetSuffix(code), CountryData)
            End Get
        End Property

        Private Sub New()
            ' Forbid construction
        End Sub


    End Class

End Namespace


