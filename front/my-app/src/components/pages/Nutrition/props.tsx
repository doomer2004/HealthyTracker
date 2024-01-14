export interface NutritionInputProps {
	label: string;
	metric: string;
	min: number;
	max: number;
	value: number;
	setValue: React.Dispatch<React.SetStateAction<number>>;
}
