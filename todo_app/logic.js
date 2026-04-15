// PURE FUNCTIONS + IMMUTABLE

const addTask = (tasks, task) => [...tasks, task];

const deleteTask = (tasks, id) =>
  tasks.filter((t) => t.id !== id);

const markDone = (tasks, id) =>
  tasks.map((t) =>
    t.id === id ? { ...t, done: true } : t
  );

const filterTasks = (tasks, filter) => {
  switch (filter.type) {
    case "open":
      return tasks.filter((t) => !t.done);

    case "done":
      return tasks.filter((t) => t.done);

    case "category":
      return tasks.filter(
        (t) => t.category === filter.value
      );

    default:
      return tasks;
  }
};

module.exports = {
  addTask,
  deleteTask,
  markDone,
  filterTasks,
};