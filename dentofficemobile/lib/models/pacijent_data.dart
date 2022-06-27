// -- pacijent_data.dart --
import 'package:json_annotation/json_annotation.dart';

part 'pacijent_data.g.dart';

@JsonSerializable()
class Pacijent_Data {
  int pacijentID;
  bool proteza;
  bool aparatic;
  bool terapija;
  int korisnikID;

  Pacijent_Data({required this.pacijentID,required this.proteza,required this.aparatic,required this.terapija,required this.korisnikID,});

  factory Pacijent_Data.fromJson(Map<String, dynamic> json) => _$Pacijent_DataFromJson(json);

  Map<String, dynamic> toJson() => _$Pacijent_DataToJson(this);
}