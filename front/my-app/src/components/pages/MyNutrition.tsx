import React, { useEffect } from "react";
import Layout from "../layout/Layout";
import {
	Accordion,
	AccordionDetails,
	AccordionSummary,
	Autocomplete,
	Backdrop,
	Box,
	Button,
	ButtonBase,
	Card,
	FormControl,
	ListItem,
	Stack,
	TextField,
	Typography
} from '@mui/material';
import { useState } from 'react';
import "../../styles/pages/myNutrition.css";
import useUser from "../../hooks/useUser";
import List from '@mui/material/List';
import NutritionCard from "../nutrition/NutritionCard";
import Meal from "../../models/meal/Meal";
import ProductAPI from "../../services/api/Products";
import MealAPI from "../../services/api/Meal";
import { AddProductFormFields } from "../../models/form/auth/AddProductFormFields";
import useNotification from "../../hooks/useNotification";
import { UpdateProductFormFields } from "../../models/form/auth/UpdateProductFromFields";
import { UpdateProductRequest } from "../../models/api/request/UpdateProductRequest";
import Daily from "../../services/api/Daily";

const MyNutrition = () => {

	const today = new Date();
	const formattedToday = today.toISOString().split('T')[0];
	const [date, setDate] = useState<string>(formattedToday);
	const [open, setOpen] = useState<boolean>(false);
	const [meals, setMeals] = useState<Meal[]>([]);
	const [loading, setLoading] = useState<boolean>(true);

	const { notifyError, notifySuccess, Notification } = useNotification();

	function setOpenOnClick() {
		setOpen(true);
	};
	const handleAddProduct = async (data: AddProductFormFields, mealId: string) => {
		await ProductAPI.addToMeal({ ...data, mealId });
		await handleLoadMeals(date);
	}

	const handleUpdateProduct = async (data: UpdateProductRequest) => {
		await ProductAPI.updateProduct(data);
		await handleLoadMeals(date);
	}

	const handleDeleteProduct = async (productId: string) => {
		await ProductAPI.deleteProduct({ productId });
		await handleLoadMeals(date);
	}

	const handleLoadMeals = async (date: string) => {
		console.log('handleLoadMeals', date)
		setLoading(true);
		const mealsResponse = await MealAPI.listByDay({ date });
		const meals = mealsResponse?.data?.meals
		setMeals(meals || []);
		setLoading(false);
	}

	useEffect(() => {
		handleLoadMeals(date)
		notifySuccess('Success!')
		notifyError('Your Norm is not enough!')
	}, [date]);

	const handleDateChange = (event: React.ChangeEvent<HTMLInputElement>) => {
		console.log(handleDateChange)
		setDate(event.target.value);
	}

	const handleCheckDaily = async () => {
		const response = await Daily.checkDaily({ date })
		if (response !== undefined && response.data === true) {
			notifySuccess('Success!')
		}
		else (response !== undefined && response.data === false) && notifyError('Your Norm is not enough!')
	}

	return (
		<Layout>
			<Box className="my-nutrition-main">
				<Stack
					className="my-nutrition-calendar"
					component="form"
					noValidate spacing={3}>
					<TextField
						id="date"
						label="Data"
						type="date"
						defaultValue={date}
						sx={{ width: 220 }}
						onChange={handleDateChange}
						InputLabelProps={{
							shrink: true,
						}}
					/>
				</Stack>

				<Box className="my-nutrition-meals">
					{loading && <Typography>Loading...</Typography>}
					{!loading && (
						meals.length > 0
							? meals.map((meal, index) => (
								<NutritionCard key={index} meal={meal} onAddProduct={(data) => handleAddProduct(data, meal.id)} onDeleteProduct={handleDeleteProduct} onUpdateProduct={(data) => handleUpdateProduct(data)} />
							))
							: <Typography>You mast be logged in</Typography>
					)}
				</Box>
				<Button
					sx={{
						display: "flex",
						justifyContent: "flex-end",
						alignItems: "center",
						marginTop: '20px',
						margin: '20px 0',
						fontSize: '16px'
					}}
					variant="contained"
					onClick={handleCheckDaily}
				>Check my nutrition</Button>
				<Notification />
			</Box>
		</Layout >
	);
}



export default MyNutrition
