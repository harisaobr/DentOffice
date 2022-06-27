// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'pregled.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

Pregled _$PregledFromJson(Map<String, dynamic> json) => Pregled(
      pregledID: json['pregledID'] as int,
      trajanjePregleda: json['trajanjePregleda'] as int,
      napomena: json['napomena'] as String,
      korisnikId: json['korisnikId'] as int,
      korisnik: Korisnik.fromJson(json['korisnik'] as Map<String, dynamic>),
      doktorIme: json['doktorIme'] as String,
      terminId: json['terminId'] as int,
      termin: Termin.fromJson(json['termin'] as Map<String, dynamic>),
      terminImePacijenta: json['terminImePacijenta'] as String,
      terminRazlog: json['terminRazlog'] as String,
      terminZavrsen: json['terminZavrsen'] as String,
      lijekId: json['lijekId'] as int,
      lijek: Lijek.fromJson(json['lijek'] as Map<String, dynamic>),
      lijekTekst: json['lijekTekst'] as String,
      dijagnozaId: json['dijagnozaId'] as int,
      dijagnoza: Dijagnoza.fromJson(json['dijagnoza'] as Map<String, dynamic>),
      dijagnozaTekst: json['dijagnozaTekst'] as String,
      pregledIme: json['pregledIme'] as String,
    );

Map<String, dynamic> _$PregledToJson(Pregled instance) => <String, dynamic>{
      'pregledID': instance.pregledID,
      'trajanjePregleda': instance.trajanjePregleda,
      'napomena': instance.napomena,
      'korisnikId': instance.korisnikId,
      'korisnik': instance.korisnik,
      'doktorIme': instance.doktorIme,
      'terminId': instance.terminId,
      'termin': instance.termin,
      'terminImePacijenta': instance.terminImePacijenta,
      'terminRazlog': instance.terminRazlog,
      'terminZavrsen': instance.terminZavrsen,
      'lijekId': instance.lijekId,
      'lijek': instance.lijek,
      'lijekTekst': instance.lijekTekst,
      'dijagnozaId': instance.dijagnozaId,
      'dijagnoza': instance.dijagnoza,
      'dijagnozaTekst': instance.dijagnozaTekst,
      'pregledIme': instance.pregledIme,
    };
