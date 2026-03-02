import GroceryListItems from "./grocerylistitems";

const API_URL = "https://api.grocerylist.danielmigchels.nl/grocerylist";
// const API_URL = "http://localhost:8080/grocerylist";

interface GroceryListModel {
  id: string;
  name: string;
}

async function getGroceryList(): Promise<GroceryListModel[]> {
  try {
    const res = await fetch(API_URL, { cache: "no-store" });
    if (!res.ok) return [];
    return (await res.json()) ?? [];
  } catch {
    return [];
  }
}

export default async function Home() {
  const groceryList = await getGroceryList();

  return (
    <main className="bg-[#303E47] text-[#fefefe] h-screen flex justify-start items-center py-12 px-4 flex-col gap-8">
      <h1 className="text-3xl font-bold">List</h1>
      <GroceryListItems groceryList={groceryList} />
    </main>
  );
}
