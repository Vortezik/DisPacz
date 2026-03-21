import React from 'react';
import { View, TextInput, Text, StyleSheet } from 'react-native';

interface Props {
  label: string;
  value: string;
  onChangeText: (text: string) => void;
}

const InputField: React.FC<Props> = ({ label, value, onChangeText }) => (
  <View style={styles.container}>
    <Text>{label}</Text>
    <TextInput style={styles.input} value={value} onChangeText={onChangeText} />
  </View>
);

const styles = StyleSheet.create({
  container: { marginBottom: 16 },
  input: { borderWidth: 1, padding: 8, borderRadius: 6 },
});

export default InputField;