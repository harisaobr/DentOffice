// -- uloga.dart --
import 'package:json_annotation/json_annotation.dart';

part 'uloga.g.dart';

@JsonSerializable()
class Uloga {
  int ulogaID;
  String naziv;
  String? opis;

  Uloga({required this.ulogaID,required this.naziv,required this.opis,});

  factory Uloga.fromJson(Map<String, dynamic> json) => _$UlogaFromJson(json);

  Map<String, dynamic> toJson() => _$UlogaToJson(this);
}