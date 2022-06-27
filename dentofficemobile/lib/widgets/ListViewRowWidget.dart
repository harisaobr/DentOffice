import 'package:flutter/material.dart';

Widget listViewRowWidget({
  final String content = "",
}) =>
    Card(
        color: const Color.fromRGBO(51, 169, 255, 1),
        margin: EdgeInsets.zero,
        child:
        TextButton(
          onPressed: () {},
          child: Padding(
            padding: const EdgeInsets.all(10),
            child: Row(
              children: [
                Expanded(
                  child: Text(
                    content,
                    style: TextStyle(color: Colors.white),
                  ),
                ),
              ],
            ),
          ),
        )
    );