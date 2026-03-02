
interface GroceryListResponseModel {
  id: string;
  name: string;
}

export default function GroceryListItems({ groceryList }: { groceryList: GroceryListResponseModel[]; }) {
  return (
    <div className="grid grid-cols-3 gap-4">
      {groceryList.map((item: GroceryListResponseModel) => (
        <div key={item.id} className="p-4 border rounded" onClick={removeGroceryListItem} ontouchhold="editgrocerylistitem">
          {item.name}
        </div>
      ))}
      <button className="p-4 border rounded">
        Add
      </button>
    </div>
  );
}