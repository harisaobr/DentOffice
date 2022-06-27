// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'korisnik.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

Korisnik _$KorisnikFromJson(Map<String, dynamic> json) => Korisnik(
      korisnikID: json['korisnikID'] as int,
      ime: json['ime'] as String,
      prezime: json['prezime'] as String,
      korisnickoIme: json['korisnickoIme'] as String,
      email: json['email'] as String,
      jmbg: json['jmbg'] as String,
      slika: json['slika'] as String,
      adresa: json['adresa'] as String,
      brojTelefona: json['brojTelefona'] as String,
      datumRodjenja: json['datumRodjenja'] == null
          ? null
          : DateTime.parse(json['datumRodjenja'] as String),
      spol: $enumDecode(_$SpolEnumMap, json['spol']),
      gradID: json['gradID'] as int,
      grad: json['grad'] == null
          ? null
          : Grad.fromJson(json['grad'] as Map<String, dynamic>),
      obavljenoPregleda: json['obavljenoPregleda'] as int,
      uloga: json['uloga'] == null
          ? null
          : Uloga.fromJson(json['uloga'] as Map<String, dynamic>),
      ulogaID: json['ulogaID'] as int,
      pacijents: (json['pacijents'] as List<dynamic>)
          .map((e) => Pacijent_Data.fromJson(e as Map<String, dynamic>))
          .toList(),
    );

Map<String, dynamic> _$KorisnikToJson(Korisnik instance) => <String, dynamic>{
      'korisnikID': instance.korisnikID,
      'ime': instance.ime,
      'prezime': instance.prezime,
      'korisnickoIme': instance.korisnickoIme,
      'email': instance.email,
      'jmbg': instance.jmbg,
      'slika': instance.slika,
      'adresa': instance.adresa,
      'brojTelefona': instance.brojTelefona,
      'datumRodjenja': instance.datumRodjenja?.toIso8601String(),
      'spol': _$SpolEnumMap[instance.spol],
      'gradID': instance.gradID,
      'grad': instance.grad,
      'obavljenoPregleda': instance.obavljenoPregleda,
      'uloga': instance.uloga,
      'ulogaID': instance.ulogaID,
      'pacijents': instance.pacijents,
    };

const _$SpolEnumMap = {
  Spol.musko: 0,
  Spol.zensko: 1,
};
