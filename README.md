# DentOffice

## Kredencijali za prijavu

- Administrator (Desktop)

  ```
  Korisnicko ime: Administrator
  Password: test
  ```
- Pacijent (Mobile)

  ```
  Korisnicko ime: Pacijent
  Password: test
  ```
- Stomatolog (Desktop)

  ```
  Korisnicko ime: Stomatolog
  Password: test
  ```
- MedicinskoOsoblje (Desktop)

  ```
  Korisnicko ime: MedicinskoOsoblje
  Password: test
  ```

#### Kredencijali za placanje

  ```
  Broj kartice: 4242 4242 4242 4242
  ```

## Pokretanje aplikacija
1. Kloniranje repozitorija
  ```
  https://github.com/harisaobr/DentOffice.git
  ```
2. Otvoriti klonirani repozitorij u konzoli
3. Pokretanje dokerizovanog API-ja i DB-a
  ```
  docker-compose build
  docker-compose up
  ```
4. Otvoriti DentOffice folder
  ```
  cd DentOffice
  ```
5. Otvoriti dentofficemobile folder
  ```
  cd dentofficemobile
  ```
6. Dohvatanje dependency-a
  ```
  flutter pub get
  ```
7. Prije pokretanja, otvoriti `lib\services\APIService.dart` i izmijeniti `apiAddress` na IP adresu vašeg internog Docker mrežnog adaptera:
  ```
  static String apiAddress = "172.19.144.1";
  ```
8. Pokretanje mobilne aplikacije
  ```
  flutter run
  ```
9. Pokretanje desktop aplikacije
  ```
  1. Otvoriti solution u Visual Studiu
  2. Postaviti `DentOffice.WinUI` kao startni projekat
  3. CTRL + F5
  ```
  
## Sistem preporuke
  

  1. Pokrenuti mobilnu aplikaciju
  2. Odabrati stranicu Ocijeni stomatologa
  3. Kliknuti na stomatologa po kome želite dobiti preporučene stomatologe
  4. Otvorit će se nova stranica sa podacima o odabranom stomatologu, te listom preporučenih stomatologa
