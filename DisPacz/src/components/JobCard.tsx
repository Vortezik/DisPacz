import React from 'react';
import { TouchableOpacity, Text, StyleSheet, View } from 'react-native';

const JobCard = ({ job, onPress }: any) => {
  const getStatusColor = () => {
    switch (job.status) {
      case 'Open': return '#FF6B6B';
      case 'In Progress': return '#FFA500';
      case 'Completed': return '#4CAF50';
      default: return '#ccc';
    }
  };

  return (
    <TouchableOpacity style={styles.card} onPress={onPress}>
      <View style={styles.header}>
        <Text style={styles.title}>{job.title}</Text>
        <Text style={[styles.status, { backgroundColor: getStatusColor() }]}>
          {job.status}
        </Text>
      </View>

      <Text style={styles.text}>Client: {job.client}</Text>
      <Text style={styles.text}>Technician: {job.technician}</Text>
    </TouchableOpacity>
  );
};

const styles = StyleSheet.create({
  card: {
    padding: 16,
    marginVertical: 8,
    backgroundColor: '#fff',
    borderRadius: 10,
    elevation: 3,
  },
  header: {
    flexDirection: 'row',
    justifyContent: 'space-between',
    marginBottom: 8,
  },
  title: {
    fontWeight: 'bold',
    fontSize: 16,
  },
  status: {
    color: '#fff',
    paddingHorizontal: 8,
    borderRadius: 5,
  },
  text: {
    color: '#555',
  },
});

export default JobCard;