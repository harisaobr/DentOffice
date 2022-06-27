// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'racun.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

Racun _$RacunFromJson(Map<String, dynamic> json) => Racun(
      racunId: json['racunId'] as int,
      korisnikId: json['korisnikId'] as int?,
      pregledId: json['pregledId'] as int?,
      ukupnaCijena: (json['ukupnaCijena'] as num?)?.toDouble(),
      datumIzdavanjaRacuna: json['datumIzdavanjaRacuna'] == null
          ? null
          : DateTime.parse(json['datumIzdavanjaRacuna'] as String),
      isPlaceno: json['isPlaceno'] as bool?,
      korisnik: Korisnik.fromJson(json['korisnik'] as Map<String, dynamic>),
      pregled: Pregled.fromJson(json['pregled'] as Map<String, dynamic>),
      ukupnaCijenaFormatted: json['ukupnaCijenaFormatted'] as String,
    );

Map<String, dynamic> _$RacunToJson(Racun instance) => <String, dynamic>{
      'racunId': instance.racunId,
      'pregledId': instance.pregledId,
      'korisnikId': instance.korisnikId,
      'ukupnaCijena': instance.ukupnaCijena,
      'datumIzdavanjaRacuna': instance.datumIzdavanjaRacuna?.toIso8601String(),
      'isPlaceno': instance.isPlaceno,
      'korisnik': instance.korisnik,
      'pregled': instance.pregled,
      'ukupnaCijenaFormatted': instance.ukupnaCijenaFormatted,
    };
