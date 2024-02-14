import Product from "../product/Product";

interface Meal {
	id: string;
	products: Product[];
	type: string;
}

export default Meal;