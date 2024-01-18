import React from "react";
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
import DateAdapter from '@mui/lab/AdapterDateFns';
import "../../styles/pages/myNutrition.css";
import { makeStyles } from "@material-ui/core/styles";
import useUser from "../../hooks/useUser";
import List from '@mui/material/List';
const MyNutrition = () => {

	const today = new Date();
	const formattedToday = today.toISOString().split('T')[0];
	const [date, setDate] = useState<string>(formattedToday);
	const [open, setOpen] = useState<boolean>(false);

	function setOpenOnClick() {
		setOpen(true);
	};


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
						InputLabelProps={{
							shrink: true,
						}}
					/>
				</Stack>

				<Box className="my-nutrition-meals">
					<Box className="my-nutrition-meal">
						<Card sx={{ display: 'flex', flexDirection: 'row', gap: 2, justifyContent: 'space-between' }}>
							<Typography>Protein: 0 g</Typography>
							<Typography>Fat 0 g</Typography>
							<Typography>Carbs: 0 g</Typography>
							<Typography>Calories: 0 g</Typography>
						</Card>
						<Accordion>
							<AccordionSummary id="panel-header" aria-controls="panel-content">
								Meal 1
							</AccordionSummary>
							<AccordionDetails>
								<Stack>
									<Button
										sx={{
											marginTop: '20px',
											alignItems: 'center',
											margin: '20px 0',
											fontSize: '16px',
										}}
										onClick={setOpenOnClick}
									>
										Add to meal
									</Button>
									<ProductsBackdrop open={open} setOpen={setOpen} />
								</Stack>
							</AccordionDetails>
						</Accordion>
					</Box>

					<Box className="my-nutrition-meal">
						<Accordion>
							<AccordionSummary id="panel-header" aria-controls="panel-content">
								Meal 1
							</AccordionSummary>
							<AccordionDetails>
								<Stack>
									<Button
										sx={{
											marginTop: '20px',
											alignItems: 'center',
											margin: '20px 0',
											fontSize: '16px',
										}}
										onClick={setOpenOnClick}
									>
										Add to meal
									</Button>
									<ProductsBackdrop open={open} setOpen={setOpen} />
								</Stack>
							</AccordionDetails>
						</Accordion>
					</Box>

					<Box className="my-nutrition-meal">
						<Accordion>
							<AccordionSummary id="panel-header" aria-controls="panel-content">
								Meal 1
							</AccordionSummary>
							<AccordionDetails>
								<Stack>
									<Button
										sx={{
											marginTop: '20px',
											alignItems: 'center',
											margin: '20px 0',
											fontSize: '16px',
										}}
										onClick={setOpenOnClick}
									>
										Add to meal
									</Button>
									<ProductsBackdrop open={open} setOpen={setOpen} />
								</Stack>
							</AccordionDetails>
						</Accordion>
					</Box>
				</Box>

			</Box>
		</Layout >
	);
}

function ProductsBackdrop(props: { open: boolean, setOpen: React.Dispatch<React.SetStateAction<boolean>> }) {
	return <>
		<Backdrop open={props.open} onClick={() => props.setOpen(false)} style={{ zIndex: 2000 }}>
			<Box sx={{ width: "85vw", height: "85vh", display: "flex", justifyContent: "center", alignItems: "center", flexDirection: "column", bgcolor: 'background.paper', boxShadow: 24 }}>
				<AddProductForm />
				<ExistingProductsList />
			</Box>
		</Backdrop>
	</>

	function ExistingProductsList() {
		// const user = useUser();
		// let products = [] as any[];
		// API.get('/meal/all-products?userId=' + user.user?.id + '&date=' + Date.now().toString())
		// 	.then((result) => {
		// 		if (!result.success) return;
		// 		products = result.data as any[];
		// 	});
		const products = [{ name: "Product 1", category: "Category 1" }, { name: "Product 2", category: "Category 2" }];
		return <Box onClick={(event) => event.stopPropagation()} sx={{ height: "80%", width: "100%" }} >
			<Typography>Existing Products:</Typography>
			<List>
				{products.map((product) => <ListItem key={product.name}>{product.name}</ListItem>)}
			</List>
		</Box>;
	}

	function AddProductForm() {
		// let products = [] as any[];
		// API.get('YOUR_GETAA_ENDPOINT').then((result) => {
		// 	if (!result.success) return;
		// 	products = result.data as any[];
		// });
		const products = [{ name: "Product 1", category: "Category 1" }, { name: "Product 2", category: "Category 2" }];
		return <Box onClick={(event) => event.stopPropagation()}
			sx={{ width: '100%', height: '20%' }}>
			<FormControl sx={{ width: '100%', height: '100%' }}>
				<Autocomplete disablePortal renderInput={(params) => <TextField {...params} id="standard-basic" label="Product" variant="standard" />}
					options={products}
					groupBy={(product) => product.category}
					getOptionLabel={(product) => product.name} />
			</FormControl>
		</Box>;
	}
}

export default MyNutrition
