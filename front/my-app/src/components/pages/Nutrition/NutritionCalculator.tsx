import React, { useState, ChangeEvent, useEffect } from 'react';
import Layout from '../../layout/Layout';
import { Box, Button, Card, FormControl, FormControlLabel, FormLabel, MenuItem, Radio, RadioGroup, Select, SelectChangeEvent, Slider, TextField, Typography } from '@mui/material';
import "./../../../styles/pages/nutritionCalculator.css";
import NutritionInput from './NutritionInput';
import { setFlagsFromString } from 'v8';
import { calculateCaffeineIntake, calculateDailyCalories, calculateFiberIntake, calculateMacronutrients, calculateSaltIntake, calculateWaterIntake } from './calculationFunctions';
import { client } from '../../../services/api';
import { UserProvider, useUser } from "../../../contexts/UserContext";



const NutritionCalculator = () => {
	const { user, loading, updateUser, refreshUser } = useUser();
	useEffect(() => {
		refreshUser();
	}, []);

	const [weight, setWeight] = useState<number>(70); // initial weight
	const [height, setHeight] = useState<number>(170); // initial height
	const [age, setAge] = useState<number>(25); // initial age
	const [bodyFatPercentage, setBodyFatPercentage] = useState<number>(20); // initial body fat percentage
	const [activityLevel, setActivityLevel] = useState<string>('1.375');
	const [goal, setGoal] = useState<string>('maintenance');
	const [gender, setGender] = useState<string>('male');
	const activityLevels = [
		{ value: '1.2', label: 'Sedentary lifestyle' },
		{ value: '1.375', label: 'Light physical activity one to three days per week' },
		{ value: '1.55', label: 'Moderate physical activity six to seven days per week' },
		{ value: '1.75', label: 'Intense physical activity daily or twice a day' },
		{ value: '1.9', label: 'Intense physical activity two or more times a day' },
	];
	const goalOptions = [
		{ value: 'deficit', label: 'Weight Loss' },
		{ value: 'maintenance', label: 'Weight Maintenance' },
		{ value: 'surplus', label: 'Weight Gain' },
	];

	const handleGoalChange = (event: SelectChangeEvent) => {
		setGoal(event.target.value as string);
	};

	const handleSelectChange = (event: SelectChangeEvent) => {
		setActivityLevel(event.target.value as string);
	};

	const handleInputChange = <T extends HTMLInputElement | HTMLTextAreaElement>(
		event: ChangeEvent<T>,
		setStateFunction: React.Dispatch<React.SetStateAction<number>>
	) => {
		const newValue = parseFloat(event.target.value);
		if (!isNaN(newValue)) {
			setStateFunction(newValue);
		}
	};

	const handleGenderChange = (event: ChangeEvent<HTMLInputElement>) => {
		setGender(event.target.value);
	};

	const handleSliderChange = (_event: Event, newValue: number | number[], setStateFunction: React.Dispatch<React.SetStateAction<number>>) => {
		setStateFunction(newValue as number);
	};

	const dailyCalories = calculateDailyCalories(weight, height, age, bodyFatPercentage, gender, parseFloat(activityLevel), goal).toFixed(2);
	const macronutrients = calculateMacronutrients(weight, height, age, bodyFatPercentage, gender, parseFloat(activityLevel), goal);
	const waterIntake = calculateWaterIntake(weight, bodyFatPercentage).toFixed(2);
	const fiberIntake: string = calculateFiberIntake(parseFloat(dailyCalories)).toFixed(2);
	const saltIntake = calculateSaltIntake(weight, bodyFatPercentage).toFixed(2);
	const caffeineNormal = calculateCaffeineIntake(weight, false).toFixed(2);
	const caffeineMax = calculateCaffeineIntake(weight, true).toFixed(2);

	const save = async () => {
		if (user != null) {
			await client.nutritionGoalPOST({
				calories: Number(dailyCalories),
				protein: macronutrients.protein,
				fat: macronutrients.fat,
				userId: 'B4D6DFF1-42E8-4DA4-7290-08DC1B865422',
				carbs: macronutrients.carbohydrates,
			})
		}
		else {
			// redirect to login
		}
	}

	return (
		<Layout>
			<Box className="nutrition-calculator">
				<p className="title">Calculate your daily nutrition</p>
				<Box className="input-main">
					<Box className="input-container">
						<Box className="input">
							<NutritionInput
								label="Weight"
								metric="kg"
								min={1}
								max={220}
								value={weight}
								setValue={setWeight}
							/>
						</Box>
						<Box className="input">
							<NutritionInput
								label="Height"
								metric="cm"
								min={1}
								max={220}
								value={height}
								setValue={setHeight}
							/>
						</Box>
					</Box>
					<Box className="input-container">
						<Box className="input">
							<NutritionInput
								label="Age"
								metric="years"
								min={1}
								max={100}
								value={age}
								setValue={setAge}
							/>
						</Box>
						<Box className="input">
							<NutritionInput
								label="Body fat percentage"
								metric="percent"
								min={1}
								max={100}
								value={bodyFatPercentage}
								setValue={setBodyFatPercentage}
							/>
						</Box>
					</Box>
				</Box>
				<Box className="main-container">
					<Box className="main-calculator">
						<Box style={{ display: 'flex', flexDirection: 'column', gap: '10px' }}>
							<Select
								labelId="activity-level-label"
								id="activity-level"
								value={activityLevel}
								onChange={handleSelectChange}
							>
								<MenuItem value="">
								</MenuItem>
								{activityLevels.map((level) => (
									<MenuItem key={level.value} value={level.value}>
										{level.label}
									</MenuItem>
								))}
							</Select>
							<Box>
								<Select
									labelId="goal-label"
									id="goal"
									value={goal}
									onChange={handleGoalChange}
								>
									{goalOptions.map((option) => (
										<MenuItem key={option.value} value={option.value}>
											{option.label}
										</MenuItem>
									))}
								</Select>
							</Box>
							<Box>
								<FormControl>
									<FormLabel id="gender-label">Gender</FormLabel>
									<RadioGroup
										aria-labelledby="gender-label"
										defaultValue="female"
										name="gender-group"
										value={gender}
										onChange={handleGenderChange}
									>
										<FormControlLabel value="female" control={<Radio />} label="Female" />
										<FormControlLabel value="male" control={<Radio />} label="Male" />
									</RadioGroup>
								</FormControl>
							</Box>
						</Box>
					</Box>
					<Card sx={{ padding: '20px', marginTop: '20px' }}>
						<Typography variant="h5">Calculation Results</Typography>
						<Typography>Daily Calories: {dailyCalories}</Typography>
						<Typography variant="h6">Macronutrients (grams)</Typography>
						<Typography>Protein: {macronutrients.protein.toFixed(2)}</Typography>
						<Typography>Fat: {macronutrients.fat.toFixed(2)}</Typography>
						<Typography>Carbohydrates: {macronutrients.carbohydrates.toFixed(2)}</Typography>
						<Typography>Water: {waterIntake}</Typography>
						<Typography>Fiber: {fiberIntake}</Typography>
						<Typography>Salt: {saltIntake}</Typography>
						<Typography>Caffeine Normal(mg): {caffeineNormal}</Typography>
						<Typography>Caffeine Max(mg): {caffeineMax}</Typography>
					</Card>
				</Box>
				<Button variant="contained" onClick={() => save()}>Save</Button>
			</Box>
		</Layout >
	);
};

export default NutritionCalculator;
