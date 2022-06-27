// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'korisnik_pacijent.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

KorisnikPacijent _$KorisnikPacijentFromJson(Map<String, dynamic> json) =>
    KorisnikPacijent(
      gradId: json['gradId'] as int?,
      grad: Grad.fromJson(json['grad'] as Map<String, dynamic>),
      ime: json['ime'] as String,
      prezime: json['prezime'] as String,
      email: json['email'] as String,
      slika: (json['slika'] as List<dynamic>).map((e) => e as int).toList(),
      jmbg: json['jmbg'] as String,
      adresa: json['adresa'] as String,
      brojTelefona: json['brojTelefona'] as String,
      datumRodjenja: DateTime.parse(json['datumRodjenja'] as String),
      korisnickoIme: json['korisnickoIme'] as String,
      uloga: Uloga.fromJson(json['uloga'] as Map<String, dynamic>),
      ulogaID: json['ulogaID'] as int,
      pacijent: Pacijent.fromJson(json['pacijent'] as Map<String, dynamic>),
      pacijentID: json['pacijentID'] as int,
      korisnikID: json['korisnikID'] as int,
      korisnici: Korisnik.fromJson(json['korisnici'] as Map<String, dynamic>),
      proteza: json['proteza'] as bool,
      aparatic: json['aparatic'] as bool,
      terapija: json['terapija'] as bool,
      imePrezime: json['imePrezime'] as String,
    );

Map<String, dynamic> _$KorisnikPacijentToJson(KorisnikPacijent instance) =>
    <String, dynamic>{
      'gradId': instance.gradId,
      'grad': instance.grad,
      'ime': instance.ime,
      'prezime': instance.prezime,
      'email': instance.email,
      'slika': instance.slika,
      'jmbg': instance.jmbg,
      'adresa': instance.adresa,
      'brojTelefona': instance.brojTelefona,
      'datumRodjenja': instance.datumRodjenja.toIso8601String(),
      'korisnickoIme': instance.korisnickoIme,
      'uloga': instance.uloga,
      'ulogaID': instance.ulogaID,
      'pacijent': instance.pacijent,
      'pacijentID': instance.pacijentID,
      'korisnikID': instance.korisnikID,
      'korisnici': instance.korisnici,
      'proteza': instance.proteza,
      'aparatic': instance.aparatic,
      'terapija': instance.terapija,
      'imePrezime': instance.imePrezime,
    };
