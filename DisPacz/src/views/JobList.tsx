import React, { useState } from 'react';
import { View, FlatList, Button, StyleSheet } from 'react-native';
import JobCard from '../components/JobCard';

const JobList = ({ navigation }: any) => {
  const [jobs] = useState([
    { id: 1, title: 'Engineering Project', client: 'WSB-NLU', technician: 'Adi', status: 'Open' },
    { id: 2, title: 'Mobile Project', client: 'JTJaskulski', technician: 'Adi', status: 'In Progress' },
    { id: 3, title: 'Task 1', client: 'JTJaskulski', technician: 'Adi', status: 'Completed' },
  ]);

   return (
    <View style={styles.container}>
      <Button
        title="Add Job"
        onPress={() => navigation.navigate('JobDetail')}
      />

      <FlatList
        data={jobs}
        keyExtractor={(item) => item.id.toString()}
        contentContainerStyle={{ marginTop: 16 }}
        renderItem={({ item }) => (
          <JobCard
            job={item}
            onPress={() => navigation.navigate('JobDetail', { job: item })}
          />
        )}
      />
    </View>
  );
};

const styles = StyleSheet.create({
  container: {
    flex: 1,
    padding: 16,
    backgroundColor: '#f5f5f5',
  },
});

export default JobList;
