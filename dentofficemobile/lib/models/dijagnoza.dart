// -- dijagnoza.dart --
import 'package:json_annotation/json_annotation.dart';

part 'dijagnoza.g.dart';

@JsonSerializable()
class Dijagnoza {
  int dijagnozaID;
  String naziv;
  String napomena;

  Dijagnoza({required this.dijagnozaID,required this.naziv,required this.napomena,});

  factory Dijagnoza.fromJson(Map<String, dynamic> json) => _$DijagnozaFromJson(json);

  Map<String, dynamic> toJson() => _$DijagnozaToJson(this);
}