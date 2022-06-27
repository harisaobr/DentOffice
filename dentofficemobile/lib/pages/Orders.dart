/*
import 'dart:collection';
import 'dart:convert';
import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:dentofficemobile/models/narudzbe.dart';
import 'package:dentofficemobile/models/proizvodi.dart';
import 'package:dentofficemobile/services/CartService.dart';
import 'package:dentofficemobile/services/APIService.dart';

class Orders extends StatefulWidget {
  @override
  _OrdersState createState() => _OrdersState();
}

class _OrdersState extends State<Orders> {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
        appBar: AppBar(
          title: Text('Korpa'),
          backgroundColor: Colors.blue,
        ),
        body: ListView(
          children:
              CartService.products.values.map((e) => CustomCard(e)).toList(),
        ));
  }

  void incrementValue(String id, bool add) {
    setState(() {
      var cm = CartService.products[id];
      if (add)
        cm.kolicina = cm.kolicina + 1;
      else
        cm.kolicina = cm.kolicina - 1;

      if(cm.kolicina == 0)
        CartService.RemoveProduct(id);
      else
        CartService.products[id] = cm;
      print(cm.kolicina);
    });
  }

  Widget CustomCard(cart) {
    return Card(
        child: Padding(
      padding: EdgeInsets.all(20),
      child: Row(
        children: [
          Expanded(
              child: Text(
            cart.proizvod.naziv,
            style: TextStyle(fontSize: 20),
          )),
          Expanded(
              child: Row(
            children: [
              TextButton(
                onPressed: () {
                  incrementValue(cart.proizvod.proizvodId.toString(), false);
                },
                child: Icon(Icons.remove, color: Colors.blue),
              ),
              SizedBox(
                width: 5,
              ),
              Text(
                cart.kolicina.toString(),
                style: TextStyle(fontSize: 20),
              ),
              SizedBox(
                width: 5,
              ),
              TextButton(
                onPressed: () {
                  incrementValue(cart.proizvod.proizvodId.toString(), true);
                },
                child: Icon(Icons.add, color: Colors.blue),
              )
            ],
          )

          ),
          FloatingActionButton(onPressed: (){
          },
            child: Text('Naruči'), backgroundColor: Colors.blue,)
        ],
      ),
    ));
  }
}
*/
