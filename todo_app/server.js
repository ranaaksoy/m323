const express = require("express");
const bodyParser = require("body-parser");

const {
  addTask,
  deleteTask,
  markDone,
  filterTasks,
} = require("./logic");

const { loadTasks, saveTasks } = require("./storage");

const app = express();
app.use(bodyParser.json());
app.use(express.static("public"));

let tasks = loadTasks();

// GET alle Tasks
app.get("/tasks", (req, res) => {
  res.json(tasks);
});

// POST Task hinzufügen
app.post("/tasks", (req, res) => {
  const newTask = {
    id: Date.now(),
    title: req.body.title,
    category: req.body.category,
    done: false,
  };

  tasks = addTask(tasks, newTask);
  saveTasks(tasks);

  res.json(tasks);
});

// DELETE
app.delete("/tasks/:id", (req, res) => {
  const id = Number(req.params.id);

  tasks = deleteTask(tasks, id);
  saveTasks(tasks);

  res.json(tasks);
});

// PATCH erledigt
app.patch("/tasks/:id", (req, res) => {
  const id = Number(req.params.id);

  tasks = markDone(tasks, id);
  saveTasks(tasks);

  res.json(tasks);
});

// FILTER
app.get("/tasks/filter/:type", (req, res) => {
  const type = req.params.type;
  const value = req.query.value;

  const filtered = filterTasks(tasks, { type, value });
  res.json(filtered);
});

app.listen(3000, () =>
  console.log("Server läuft auf http://localhost:3000")
);