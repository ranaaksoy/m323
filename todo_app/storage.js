const fs = require("fs");

const FILE = "tasks.json";

const loadTasks = () => {
  try {
    return JSON.parse(fs.readFileSync(FILE));
  } catch {
    return [];
  }
};

const saveTasks = (tasks) => {
  fs.writeFileSync(FILE, JSON.stringify(tasks, null, 2));
};

module.exports = { loadTasks, saveTasks };