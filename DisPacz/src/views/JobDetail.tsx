import React, { useState } from 'react';
import { Button, ScrollView, Alert, StyleSheet } from 'react-native';
import InputField from '../components/InputField';

const JobDetail = ({ route, navigation }: any) => {
  const existing = route.params?.job;

  const [title, setTitle] = useState(existing?.title || '');
  const [client, setClient] = useState(existing?.client || '');
  const [technician, setTechnician] = useState(existing?.technician || '');
  const [status, setStatus] = useState(existing?.status || 'Open');

  const handleSave = () => {
    console.log({
      title,
      client,
      technician,
      status,
    });

    Alert.alert('Success', 'Job saved');
    navigation.goBack();
  };

  const handleDelete = () => {
    Alert.alert('Deleted', 'Job deleted');
    navigation.goBack();
  };

  return (
    <ScrollView style={styles.container}>
      <InputField label="Job Title" value={title} onChangeText={setTitle} />
      <InputField label="Client" value={client} onChangeText={setClient} />
      <InputField label="Technician" value={technician} onChangeText={setTechnician} />
      <InputField label="Status" value={status} onChangeText={setStatus} />

      <Button title="Save Job" onPress={handleSave} />

      {existing && (
        <Button title="Delete Job" color="red" onPress={handleDelete} />
      )}
    </ScrollView>
  );
};

const styles = StyleSheet.create({
  container: {
    padding: 16,
  },
});

export default JobDetail;