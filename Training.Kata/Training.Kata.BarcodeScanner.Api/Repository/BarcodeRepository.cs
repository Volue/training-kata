using Training.Kata.BarcodeScanner.Api.Model;

namespace Training.Kata.BarcodeScanner.Api.Repository;

public class BarcodeRepository
{
    public Dictionary<string, Product> Barcodes;

    public BarcodeRepository()
    {
        Barcodes = new Dictionary<string, Product>
        {
            {
                "3908a54e-3811-453e-9413-968453f8d91c", new Product
                {
                    Barcode = "3908a54e-3811-453e-9413-968453f8d91c",
                    Name = "Świerk serbski (Picea omorica)",
                    Description =
                        @"Świerk serbski marki 4 Flower.
                        Najszybciej rosnący gatunek świerka, tworzący wąską, strzelistą koronę.
                        Po 30latach - do 10 m wys.
                        Gałęzie boczne, często łukowato zagięte - charakterystyczny ciekawy pokrój.
                        Polecany do niedużych ogrodów, ze względu na stosunkowo niewielką średnicę.
                        Małe wymagania glebowe i wilgotnościowe.
                        Stanowisko słoneczne.
                        Odporny na zanieczyszczenia środowiska.
                        Roślina w doniczce 2l",
                    Price = 22.99m
                }
            },

            {
                "9e99608f-613b-4842-8967-e9153091ceb7", new Product
                {
                    Barcode = "9e99608f-613b-4842-8967-e9153091ceb7",
                    Name = "Hortensja ogrodowa (Hydrangea macrophylla)",
                    Description =
                        @"Hortensja ogrodowa (Hydrangea macrophylla)
Niezwykle romantyczna roślina o wyjątkowo dużych kwiatach. Idealna do letnich i jesiennych bukietów. Kwiaty doskonale nadają się do zasuszania. Kwitnie do przymrozków. Roślina polecana do nasadzeń ogrodowych - w miejscach eksponowanych. Możliwa również uprawa w donicach.
Podłoże żyzne, kwaśne, stale wilgotne.
Stanowisko półcieniste.
Wskazane okrywanie na zimę.",
                    Price = 39.99m
                }
            },

            {
                "41ce2448-9f60-48d8-9ac3-c4e0eb0d80eb", new Product
                {
                    Barcode = "41ce2448-9f60-48d8-9ac3-c4e0eb0d80eb",
                    Name = "Jaśmin Stefana (Jasminum sp.)",
                    Description =
                        @"Cechy
Jaśmin Stefana ceniony jest za wyjątkowy aromat. Osiąga wysokość do 5 m. Jest to roślina dość szybko rosnąca (rocznie od 1 do 2 m), mrozoodporna, może zimować w gruncie. W uprawie doniczkowej nie osiąga tak imponujących rozmiarów. Pędy jaśminu Stefana są cienkie, giętkie, długie i wijące się. Dobrze znosi cięcie - należy przycinać pędy sekatorem do połowy długości tuż po kwitnieniu.
Zastosowanie
Jaśmin pnący jest stosowany jako pnącze ozdobne w przydomowych ogrodach, szklarniach, balkonach, przy pergolach, a czasami również w mieszkaniach. Pędy mocuje się lub oplata na podporach (kratkach, formach wykonanych z drutu, pałąkach), można również uprawiać jaśmin w pojemnikach na tarasach i balkonach. Jaśmin pnący różowy to roślina do całorocznego sadzenia.
Zalety
Jaśmin doniczkowy można posadzić blisko okna lub tarasu, aby delektować się jego aromatem - kwiaty wydzielają intensywny, słodki zapach. Pędy są gęsto okryte drobnymi, pierzastymi, sezonowymi, jasnozielonymi liśćmi. Wymaga stanowiska słonecznego bądź półcienistego. Gleba pod jaśmin Stefana powinna być żyzna i wilgotna - polecany jest odpowiedni nawóz. Ten wspaniały, pięknie wyglądający kwiat jest dostępny w wyjątkowo atrakcyjnej cenie!",
                    Price = 16.99m
                }
            },
        };
    }
}