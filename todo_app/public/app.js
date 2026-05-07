const API = "http://localhost:3000";

// Render
const render = (tasks) => {
  const list = document.getElementById("list");
  list.innerHTML = "";

  tasks.map((t) => {
    const li = document.createElement("li");

    li.innerHTML = `
      ${t.title} [${t.category}] ${t.done ? "✅" : "❌"}
      <button onclick="done(${t.id})">✔</button>
      <button onclick="del(${t.id})">X</button>
    `;

    list.appendChild(li);
  });
};

// Load
const loadTasks = async () => {
  const res = await fetch(`${API}/tasks`);
  const data = await res.json();
  render(data);
};

// add
const addTask = async () => {

  const title = document.getElementById("title").value;

  const category = document.getElementById("category").value;

  await fetch(`${API}/tasks`, {

    method: "POST",

    headers: { "Content-Type": "application/json" },

    body: JSON.stringify({ title, category }),

  });

  loadTasks();

};

// Delete

const del = async (id) => {

  await fetch(`${API}/tasks/${id}`, {

    method: "DELETE",

  });

  loadTasks();

};

// Done

const done = async (id) => {

  await fetch(`${API}/tasks/${id}`, {

    method: "PATCH",

  });

  loadTasks();

};

// Filter

const filter = async (type) => {

  const res = await fetch(`${API}/tasks/filter/${type}`);

  const data = await res.json();

  render(data);

};

// Kategorie Filter

const filterCategory = async () => {

  const value = document.getElementById("filterCat").value;

  const res = await fetch(

    `${API}/tasks/filter/category?value=${value}`

  );

  const data = await res.json();

  render(data);

};

// Start

loadTasks();