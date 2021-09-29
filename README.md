## CLI
* Nowy projekt
	* konsolowy
	```
	dotnet new console [-o <LOKALIZACJA> -n <NAZWA_PROEKTU>]
	```	
	* WebAPI
	```
	dotnet new webapi [-o <LOKALIZACJA> -n <NAZWA_PROEKTU>] [--no-hhtps]
	```
	* biblioteki
	```
	dotnet new classlib [-o <LOKALIZACJA> -n <NAZWA_PROEKTU>]
	```
* Kompilacja i uruchomienie
	```
	dotnet build
	dotnet <NAZWA_PROJEKTU>.dll [<PARAMETRY>]
	```
	```
	dotnet [watch] run [PARAMETRY]
	```
* Publikacja
	* plik wykonywalny zależny od platformy dla bieżącej platformy
	```
	dotnet publish
	```
	* plik wykonywalny zależny od platformy dla określonej platformy
	```
	dotnet publish -r <IDENTYFIKATOR_ŚRODOWISKA> --self-contained false
	```
	* samodzielny plik wykonywalny
	```
	dotnet publish -r <IDENTYFIKATOR_ŚRODOWISKA>
	```
	* samodzielny plik wykonywalny + ReadyToRun
	```
	dotnet publish -r <IDENTYFIKATOR_ŚRODOWISKA> -p:PublishReadyToRun=true
	```
* Pakiety i referencje
	* Dodawanie pakietów
	```
	dotnet add package <NAZWA_PAKIETU>
	```
	* Pobranie pakietów
	```
	dotnet restore
	```
	* Dodawanie referencji
	```
	dotnet add reference <ŚCIEŻKA_PROJEKTU>
	```
