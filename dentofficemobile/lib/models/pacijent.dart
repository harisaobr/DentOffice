// -- pacijent.dart --
import 'package:dentofficemobile/models/korisnik.dart';
import 'package:json_annotation/json_annotation.dart';

part 'pacijent.g.dart';

@JsonSerializable()
class Pacijent {
  int pacijentID;
  bool proteza;
  bool aparatic;
  bool terapija;
  int korisnikID;
  Korisnik korisnik;

  Pacijent(this.pacijentID,this.proteza,this.aparatic,this.terapija,this.korisnikID,this.korisnik,);

  factory Pacijent.fromJson(Map<String, dynamic> json) => _$PacijentFromJson(json);

  Map<String, dynamic> toJson() => _$PacijentToJson(this);
}
