import 'package:flutter/material.dart';
import 'package:demo_codingvpr/data/databasehelper.dart';
import 'package:demo_codingvpr/model/todo.dart';
import 'package:demo_codingvpr/pages/mapas.dart';
import 'package:demo_codingvpr/pages/fotos.dart';

void main() {
  runApp(MyApp());
}

class MyApp extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      debugShowCheckedModeBanner: false,
      title: 'Flutter Demo',
      theme: ThemeData(
        primarySwatch: Colors.purple,
        visualDensity: VisualDensity.adaptivePlatformDensity,
      ),
      home: MyHomePage(title: 'Lista de tareas'),
    );
  }
}

class MyHomePage extends StatefulWidget {
  MyHomePage({Key key, this.title}) : super(key: key);

  final String title;

  @override
  _MyHomePageState createState() => _MyHomePageState();
}

class _MyHomePageState extends State<MyHomePage> {
  TextEditingController textController = new TextEditingController();

  List<Todo> taskList = new List();

  @override
  void initState() {
    super.initState();

    DatabaseHelper.instance.queryAllRows().then((value) {
      setState(() {
        value.forEach((element) {
          taskList.add(Todo(id: element['id'], title: element["title"]));
        });
      });
    }).catchError((error) {
      print(error);
    });
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
        appBar: AppBar(
          title: Text(widget.title),
        ),
        body: Container(
          alignment: Alignment.topLeft,
          padding: EdgeInsets.all(16),
          child: Column(
            children: <Widget>[
              Row(
                children: <Widget>[
                  Expanded(
                    child: TextFormField(
                      decoration:
                          InputDecoration(hintText: "Ingrese una tarea"),
                      controller: textController,
                    ),
                  ),
                  IconButton(
                    icon: Icon(Icons.add),
                    onPressed: _addToDb,
                  )
                ],
              ),
              SizedBox(height: 20),
              Expanded(
                child: Container(
                  child: taskList.isEmpty
                      ? Container()
                      : ListView.builder(itemBuilder: (ctx, index) {
                          if (index == taskList.length) return null;
                          return ListTile(
                            title: Text(taskList[index].title),
                            leading: Text(taskList[index].id.toString()),
                            trailing: IconButton(
                              icon: Icon(Icons.delete),
                              onPressed: () => _deleteTask(taskList[index].id),
                            ),
                          );
                        }),
                ),
              )
            ],
          ),
        ),
        floatingActionButton:
            Column(mainAxisAlignment: MainAxisAlignment.end, children: [
          FloatingActionButton(
            child: Icon(Icons.map),
            backgroundColor: Colors.green,
            tooltip: "Ir a Mapa",
            onPressed: () {
              //...
              Navigator.of(context)
                  .push(MaterialPageRoute(builder: (context) => Mapas()));
            },
            heroTag: null,
          ),
          SizedBox(
            height: 10,
          ),
          FloatingActionButton(
            child: Icon(Icons.camera_alt),
            backgroundColor: Colors.green,
            tooltip: "Ir a Fotos",
            onPressed: () {
              //...
              Navigator.of(context)
                  .push(MaterialPageRoute(builder: (context) => Fotos()));
            },
            heroTag: null,
          )
        ]));
  }

  void _deleteTask(int id) async {
    await DatabaseHelper.instance.delete(id);
    setState(() {
      taskList.removeWhere((element) => element.id == id);
    });
  }

  void _addToDb() async {
    String task = textController.text;
    var id = await DatabaseHelper.instance.insert(Todo(title: task));
    setState(() {
      taskList.insert(0, Todo(id: id, title: task));
    });
  }
}
