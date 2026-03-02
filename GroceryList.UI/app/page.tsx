import GroceryListItems from "./grocerylistitems";

interface GroceryListResponseModel {
  id: string;
  name: string;
}

async function getGroceryList(): Promise<GroceryListResponseModel[]> {
  try {
    const res = await fetch("https://api.grocerylist.danielmigchels.nl/grocerylist", {
      cache: "no-store",
    });
    if (!res.ok) return [];
    const data: GroceryListResponseModel[] = await res.json();
    return data ?? [];
  } catch {
    return [];
  }
}

export default async function Home() {

  const groceryList = await getGroceryList();

  return (
    <main className="flex justify-center items-center py-12 px-4 flex-col gap-4">
      <h1 className="text-3xl font-bold">Grocery list</h1>
      <GroceryListItems groceryList={groceryList} />
    </main>
  );
}
