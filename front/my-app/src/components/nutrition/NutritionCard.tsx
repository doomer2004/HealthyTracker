import { Accordion, AccordionDetails, AccordionSummary, Box, Button, Card, Stack, Typography, Tooltip, IconButton } from "@mui/material"
import DeleteIcon from '@mui/icons-material/Delete';
import BuildIcon from '@mui/icons-material/Build';
import { ProductsBackdrop } from "./ProductsBackdrop";
import { useState, useCallback, useMemo } from "react";
import { AddProductForm } from "./AddProductForm";
import { UpdateProductForm } from "./UpdateProductForm";
import { AddProductFormFields } from "../../models/form/auth/AddProductFormFields";
import Meal from "../../models/meal/Meal";
import Product from "../../models/product/Product";
import { UpdateProductRequest } from "../../models/api/request/UpdateProductRequest";

interface NutritionCardProps {
	meal: Meal;
	onAddProduct: (data: AddProductFormFields) => Promise<void>;
	onDeleteProduct: (productId: string) => Promise<void>;
	onUpdateProduct: (data: UpdateProductRequest) => Promise<void>;
}

const getProductDescription = (product: Product): string => {
	return `Caffeine:${product.caffeine}\nSalt:${product.salt}\nWater:${product.water}\nCarbs:${product.carbs}\nFat:${product.fat}\nProtein:${product.protein}\nVolume:${product.volume}\nCalories:${product.calories}`;
}

const NutritionCard = ({ meal, onAddProduct, onDeleteProduct, onUpdateProduct }: NutritionCardProps) => {
	const [openAdd, setOpenAdd] = useState<boolean>(false);
	const [openUpdate, setOpenUpdate] = useState<boolean>(false);

	const handleAddOpenClick: React.MouseEventHandler<HTMLButtonElement> = useCallback((e) => {
		setOpenAdd(true);
	}, [setOpenAdd])

	const handleUpdateOpenClick: React.MouseEventHandler<HTMLButtonElement> = useCallback((e) => {
		setOpenUpdate(true);
	}, [setOpenUpdate])

	const handleAddClose = useCallback(() => {
		setOpenAdd(false);
	}, [setOpenAdd])

	const handleUpdateClose = useCallback(() => {
		setOpenUpdate(false);
	}, [setOpenUpdate])

	const { protein, fat, carbs, calories } = useMemo(() => {
		return meal.products.reduce((acc, curr) => {
			acc.protein += curr.protein;
			acc.fat += curr.fat;
			acc.carbs += curr.carbs;
			acc.calories += curr.calories;
			return acc;
		}, { protein: 0, fat: 0, carbs: 0, calories: 0 })
	}, [meal.products])

	const handleDelete = (productId: string) => {
		onDeleteProduct(productId);
	}

	const handleUpdate = (data: UpdateProductRequest) => {
		onUpdateProduct(data);
	}

	return (
		<Box className="my-nutrition-meal">
			<Card sx={{ display: 'flex', flexDirection: 'row', gap: 2, justifyContent: 'space-between' }}>
				<Typography>Protein: {Math.round(protein)} g</Typography>
				<Typography>Fat {Math.round(fat)} g</Typography>
				<Typography>Carbs: {Math.round(carbs)} g</Typography>
				<Typography>Calories: {Math.round(calories)} g</Typography>
			</Card>
			<Accordion>
				<AccordionSummary id="panel-header" aria-controls="panel-content" style={{ display: 'flex', justifyContent: 'space-between' }}>
					<Typography sx={{ textTransform: 'uppercase', alignItems: 'center', display: 'flex', justifyContent: 'space-between' }}>{meal.type}</Typography>
				</AccordionSummary>
				<AccordionDetails>
					<ol>
						{meal.products.map((product, index) => (
							<li><Tooltip title={<pre>{getProductDescription(product)}</pre>}><Typography sx={{ textTransform: 'uppercase' }} key={product.productName}>{product.productName}
								<IconButton
									onClick={() => handleDelete(product.productId)}>
									<DeleteIcon />
								</IconButton>
								<IconButton
									onClick={handleUpdateOpenClick}>
									<BuildIcon />
								</IconButton>
								<ProductsBackdrop open={openUpdate} onClose={handleUpdateClose} >
									<UpdateProductForm onSubmit={(body) => {
										handleUpdate({ ...body, productId: product.productId });
									}} />
								</ProductsBackdrop>
							</Typography></Tooltip></li>
						))}
					</ol>
					<Stack>
						<Button
							sx={{
								marginTop: '20px',
								alignItems: 'center',
								margin: '20px 0',
								fontSize: '16px',
							}}
							onClick={handleAddOpenClick}
						>
							Add to meal
						</Button>
						<ProductsBackdrop open={openAdd} onClose={handleAddClose} >
							<AddProductForm onSubmit={onAddProduct} />
						</ProductsBackdrop>
					</Stack>
				</AccordionDetails>
			</Accordion>
		</Box>
	)
}

export default NutritionCard;