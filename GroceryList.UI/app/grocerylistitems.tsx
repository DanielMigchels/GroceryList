
"use client";

import { useState } from "react";

const API_URL = "https://api.grocerylist.danielmigchels.nl/grocerylist";
// const API_URL = "http://localhost:8080/grocerylist";

interface GroceryListModel {
  id: string;
  name: string;
}

export default function GroceryListItems({ groceryList: initialList }: { groceryList: GroceryListModel[] }) {
  const [items, setItems] = useState<GroceryListModel[]>(initialList);
  const [newName, setNewName] = useState("");
  const [editingId, setEditingId] = useState<string | null>(null);
  const [editName, setEditName] = useState("");

  async function addItem() {
    const name = newName.trim();
    if (!name) return;

    await fetch(API_URL, {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify({ name }),
    });

    setNewName("");
    await refreshList();
  }

  async function removeItem(item: GroceryListModel) {
    await fetch(API_URL, {
      method: "DELETE",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify({ id: item.id, name: item.name }),
    });

    await refreshList();
  }

  async function saveEdit(item: GroceryListModel) {
    const name = editName.trim();
    if (!name || name === item.name) {
      setEditingId(null);
      return;
    }

    await fetch(API_URL, {
      method: "PUT",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify({ id: item.id, name }),
    });

    setEditingId(null);
    await refreshList();
  }

  async function refreshList() {
    try {
      const res = await fetch(API_URL, { cache: "no-store" });
      if (res.ok) setItems(await res.json());
    } catch { }
  }

  function startEdit(item: GroceryListModel) {
    setEditingId(item.id);
    setEditName(item.name);
  }

  return (
    <div className="grid grid-cols-1 gap-4 w-full max-w-xl">
      {items.map((item) => (
        <div key={item.id} className="bg-[#F16A70] rounded flex justify-between items-center gap-2 cursor-pointer">
          {editingId === item.id ? 
          (
            <input className="outline-none py-2 px-4 bg-transparent" value={editName} onChange={(e) => setEditName(e.target.value)} onBlur={() => saveEdit(item)} onKeyDown={(e) => e.key === "Enter" && saveEdit(item)} autoFocus/>
          ) : (
            <>
              <span className="py-2 px-4 bg-transparent" onClick={() => startEdit(item)}>
                {item.name}
              </span>
              <button className="text-[#303E47] cursor-pointer py-2 px-4" onClick={() => removeItem(item)}>
                Delete
              </button>
            </>
          )}
        </div>
      ))}

      <div className="rounded flex items-center gap-2">
        <input className="py-2 px-4 bg-[#fefefe] text-[#303E47] w-full outline-none rounded" placeholder="I need ..." value={newName} onChange={(e) => setNewName(e.target.value)} onKeyDown={(e) => e.key === "Enter" && addItem()} />
        <button className="py-2 px-4 bg-[#308576] text-white rounded cursor-pointer w-32" onClick={addItem}>Add</button>
      </div>
    </div>
  );
}