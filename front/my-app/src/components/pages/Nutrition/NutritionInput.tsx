import React, { ChangeEvent } from "react";
import { Box, Slider, TextField, Typography } from '@mui/material';
import { NutritionInputProps } from "./props";

const NutritionInput: React.FC<NutritionInputProps> = (
	{ label, metric, min, max, value, setValue }) => {
	const handleSliderChange = (_event: Event, newValue: number | number[], setStateFunction: React.Dispatch<React.SetStateAction<number>>) => {
		setStateFunction(newValue as number);
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

	return (
		<Box>
			<Typography id="input-slider" gutterBottom>
				{label}
			</Typography>
			<Slider
				value={value}
				max={max}
				min={min}
				onChange={(_event, newValue) => handleSliderChange(_event, newValue, setValue)}
				aria-labelledby="input-slider"
			/>
			<TextField
				type="number"
				label={`${label} ${metric}`}
				value={value}
				onChange={(event) => handleInputChange(event, setValue)}
				inputProps={{ min: '0', step: '1' }}
				style={{ width: '100px', marginTop: '10px' }}
			/>
		</Box>
	);
};

export default NutritionInput;
