import React from "react";
import Layout from "../layout/Layout";
import { Accordion, AccordionDetails, AccordionSummary, Box, Button, ButtonBase, Card, Stack, TextField, Typography } from '@mui/material';
import { useState } from 'react';
import DateAdapter from '@mui/lab/AdapterDateFns';
import "../../styles/pages/myNutrition.css";
const MyNutrition = () => {

	const today = new Date();
	const formattedToday = today.toISOString().split('T')[0];
	const [date, setDate] = useState<string>(formattedToday);



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
									>
										Add to meal
									</Button>
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

								</Stack>
							</AccordionDetails>
						</Accordion>
					</Box>
				</Box>

			</Box>
		</Layout >
	);


}

export default MyNutrition