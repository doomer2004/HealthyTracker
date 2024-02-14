import { Backdrop, Box } from "@mui/material"
import { AddProductForm } from "./AddProductForm"

interface ProductsBackdropProps {
	open: boolean,
	onClose: () => void,
	children: React.ReactNode
}

export const ProductsBackdrop = ({ open, onClose, children }: ProductsBackdropProps) => {
	const handleClose: React.MouseEventHandler<HTMLElement> = (e) => {
		onClose();
	}
	const handleInnerClick = (e: React.MouseEvent<HTMLElement>) => {
		e.stopPropagation();
	}
	return <>
		<Backdrop open={open} onClick={handleClose} style={{ zIndex: 2000 }}>
			<Box onClick={handleInnerClick} sx={{ width: "30vw", height: "30vh", display: "flex", justifyContent: "center", alignItems: "center", flexDirection: "column", bgcolor: 'background.paper', boxShadow: 24 }}>
				{children}
			</Box>
		</Backdrop>
	</>

	// function ExistingProductsList() {
	// 	// const user = useUser();
	// 	// let products = [] as any[];
	// 	// API.get('/meal/all-products?userId=' + user.user?.id + '&date=' + Date.now().toString())
	// 	// 	.then((result) => {
	// 	// 		if (!result.success) return;
	// 	// 		products = result.data as any[];
	// 	// 	});
	// 	const products = [{ name: "Product 1", category: "Category 1" }, { name: "Product 2", category: "Category 2" }];
	// 	return <Box onClick={(event) => event.stopPropagation()} sx={{ height: "80%", width: "100%" }} >
	// 		<Typography>Existing Products:</Typography>
	// 		<List>
	// 			{products.map((product) => <ListItem key={product.name}>{product.name}</ListItem>)}
	// 		</List>
	// 	</Box>;
	// }
}