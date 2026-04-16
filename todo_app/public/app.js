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